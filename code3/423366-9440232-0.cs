    public void PasteFromCopy(string source,string dest)
    {
        lock(this)
        {
            if (IsFolder(source))
            {
                CopyDirectory(source, dest);
            }
            else
            {
                CopyStream(source, dest); 
            }
        }
    }
