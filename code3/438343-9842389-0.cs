    private void FileOpenCore(string filename)
    {
        try
        {
            // read your file
            // and do whatever processing you need
            // ...
            // if open was successful
            RecentFileList.InsertFile(filename);
        }
        catch (Exception e)
        {
            // opening the file failed - maybe it doesn't exist anymore 
            // or maybe it's corrupted
            RecentFileList.RemoveFile(filename);
            // Do whatever other error processing you want to do.
        }
    }
