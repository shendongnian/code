    private void displayMessageBox(object sender, FormClosingEventArgs e)
        {
        DialogResult result = MessageBox.Show("Do you want to save the changes to the document before closing it?", "MyNotepad",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            saveToolStripMenuItem_Click(sender, e);
        }
        else if (result == DialogResult.No)
        {
            rtbMain.Clear();
            this.Text = "Untitled - MyNotepad"; 
        }
        else if (result == DialogResult.Cancel)
        {
            // Leave the window open.
            e.Cancel = true;
        }
