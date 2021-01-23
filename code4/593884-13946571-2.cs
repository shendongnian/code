    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        string filename = "abc:file.jpg";
    
        if (!IsValidFilename(filename)) {
            filename = MakeFilenameValid(filename, "_");
        }
    
        MessageBox.Show(filename);
    
    }
