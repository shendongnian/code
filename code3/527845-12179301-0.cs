    private void SearchDirectory(string folder)
    {
        foreach (string file in Directory.GetFiles(folder))
        {
            try 
            {
                // do work;
            }
            catch 
            {
                // access to the file has been denied
            }
        }
        foreach (string subDir in Directory.GetDirectories(folder))
        {
            try 
            {   
                 SearchDirectory(subDir);
            }
            catch 
            {
                // access to the folder has been denied
            }
            
        }
    }
