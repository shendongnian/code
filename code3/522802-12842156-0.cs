    public String LastSelectedFolder;
    
    private void btnBrowse_Click(object sender, EventArgs e)
    {
        fbFolderBrowser.InitialDirectory=this.Settings.Button1Path;
        if (fbFolderBrowser.ShowDialog() == DialogResult.OK)
        {
            // Save Last selected folder.
            LastSelectedFolder = fbFolderBrowser.SelectedPath;
        }
    }
