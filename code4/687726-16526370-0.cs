    private object key = new object();
    public void FileLog(string file, string project, string type, string fileNr, string note)
    {
        lock(key)
        {
            //your existing implementation goes here
        }
    }
