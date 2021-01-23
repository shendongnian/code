     static void RecursiveGetFiles(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        try
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                MessageBox.Show(file.FullName);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied to folder: " + path);
        }
        foreach (DirectoryInfo lowerDir in dir.GetDirectories())
        {
            try
            {
                RecursiveGetFiles(lowerDir.FullName);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied to folder: " + path);
            }
        }
    }
    }
