    private void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            string[] files = openFileDialog1.FileNames;
    
            if (files != null && files.Length > 0)
            {
                // returns the root directory
                string folder = System.IO.Path.GetDirectoryName(files[0]);
    
                // Obtain the file system entries in the directory path.
                string[] directoryEntries =
                    System.IO.Directory.GetFileSystemEntries(folder); 
            }
        }
    
    }
