    [DebuggerNonUserCode]
    public static bool IsArchive(string filename)
    {
        bool result = false;
        try
        {
            //this calls an external library, which throws an exception if the file is not an archive
            result = ExternalLibrary.IsArchive(filename);
        }
        catch
        {
    
        }
        return result;
    }
