    void AwaitFile()
    {
        //Your File
        var file  = new FileInfo("yourFile");
    
        //While File is not accesable because of writing process
        while (!FileIsAvailable(file)) { }
    
        //File is available here
                
    }
    
    /// <summary>
    /// Code by ChrisW -> http://stackoverflow.com/questions/876473/is-there-a-way-to-check-if-a-file-is-in-use
    /// </summary>
    bool FileIsAvailable(FileInfo file)
    {
        FileStream stream = null;
    
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    
        //file is not locked
        return false;
    }
