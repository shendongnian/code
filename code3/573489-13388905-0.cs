    private void browse_Click(object sender, EventArgs e)
    {
        //browse to select a folder
        FolderBrowserDialog folder = new FolderBrowserDialog();
        DialogResult result = folder.ShowDialog();
        if (result == DialogResult.OK)
        {
            installPath.Text = folder.SelectedPath;
            MessageBox.Show("You chose" + folder.SelectedPath);
        }
        else if (result == DialogResult.Cancel)
        {
            return;
        }
    }
