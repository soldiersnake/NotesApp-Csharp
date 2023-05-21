using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class Form1 : Form
    {
        List<Note> _notes = new List<Note>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtName.Text))
            {
                var note = new Note();
                note.Title = txtTitle.Text;
                note.Notes = txtTitle.Text;
            
                _notes.Add(note);
            }
            PopulateNotes();
            ClearForm();
        }

        private void PopulateNotes()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _notes;
            grdNotes.DataSource = bs;
        }
        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if(grdNotes.SelectedRows != null)
            {
                var title = grdNotes.SelectedCells[0].Value.ToString();
                var notes = GetNotesByTitle(title);

                txtTitle.Text= title;
                txtName.Text = notes;
            }
        }

        private string GetNotesByTitle(string title)
        {
            var notes = string.Empty;

            foreach (var note in _notes)
            {
                if(note.Title == title)
                    notes = note.Notes;
            }

            return notes;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(grdNotes.SelectedRows != null)
            {
                var title = grdNotes.SelectedCells[0].Value.ToString();   
                DeleteByTitle(title);
                PopulateNotes();
            }
        }

        private void DeleteByTitle(string title)
        {
            Note noteToRemove = null;

            foreach (var note in _notes)
            {
                if(note.Title == title)
                    noteToRemove = note;
            }
            if(noteToRemove != null)
                _notes.Remove(noteToRemove);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(txtName.Text != null && txtTitle.Text != null)
            {
                txtTitle.Text = "";
                txtName.Text = "";
            }
            //ClearForm();
        }
    }
}
