    public void OnChanged(object sender, FileSystemEventArgs e)
    {
        string FileName = System.IO.Path.GetFileName(e.FullPath);
        if(IsAvailable(System.IO.Path.Combine(RecievedPath,FileName)))
        {
            ProcessMessage(FileName);
        }
    }
    private void ProcessMessage(string fileName)
    {
        try
        {
           File.Copy(System.IO.Path.Combine(RecievedPath,fileName), System.IO.Path.Combine(SentPath,fileName));
            MessageBox.Show("File Copied");
        }
        catch (Exception)
        { }
    }
    private static bool IsAvailable(String filePath)
    {
        try
        {
            using (FileStream inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                if (inputStream.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
