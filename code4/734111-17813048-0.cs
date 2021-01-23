    public bool DownloadFile(string getFile, string downloadToPath)
    {
        if(string.IsNullOrWhiteSpace(getFile) || string.IsNullOrWhiteSpace(downloadToPath)) return false;
    
        try
        {
            using(var readStream = File.OpenRead(getFile))
            using(var writeStream = File.OpenWrite(downloadToPath))
            {
                readStream.CopyTo(writeStream, 1024);
            }
        }
        catch(Exception e)
        {
            // log exception or rethrow
            return false;
        }
        
        return true;
    }
