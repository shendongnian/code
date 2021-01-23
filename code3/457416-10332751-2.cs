    private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
            {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox)
                    this.Controls.Remove(ctrl);
            }
            //Your code
