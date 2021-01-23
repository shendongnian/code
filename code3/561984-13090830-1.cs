    private void browsebutton2_Click(object sender, EventArgs e)
    {
        klantenDatabaseTextbox.Text=browseDatabase( "accdb bestanden|*.accdb");
    }
    private string browseDatabase(string filter)
    {
        openFileDialogDB.Filter = filter;
        if (openFileDialogDB.ShowDialog() == DialogResult.OK)
        {
            string DBfile = openFileDialogDB.FileName;
            if (System.IO.File.Exists(DBfile))
            {
                return DBfile;
            }
            else
            {
                MessageBox.Show("Selected file doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("No file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
     return "";
    }
