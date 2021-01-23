    private void EmptyFolderContents(string folderName)
    {
        if(Directory.Exists(folderName)
        {
            foreach (var folder in Directory.GetDirectories(folderName))
            {
                try
                {
                    Directory.Delete(folder, true);
                }
                catch(Exception ex)                
                {
                     MessageBox.Show("Error deleting folder: " + folder+ Environment.NewLine + ex.Message);
                }
            }
            foreach (var file in Directory.GetFiles(folderName))
            {
                try
                {
                    File.Delete(file);
                }
                catch(Exception ex)
                {
                     MessageBox.Show("Error deleting file: " + file + Environment.NewLine + ex.Message);
                }
            }
        }
