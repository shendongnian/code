    public string SearchFileSystem(string filename)
    {
        string [] files = null;
        try
        {
             files = Directory.GetFiles("C:\\", filename, SearchOption.AllDirectories);
        }
        catch (Exception e)
        {
             MessageBox.Show(e.Message);
        }
        return files==null?null:files.FirstOrDefault();
    }
