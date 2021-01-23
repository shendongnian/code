    public int GetFile(string path, out string error)
    {
        error = string.Empty.
        int i;
        try
        {
            //...
            return i;
        }
        catch(Exception ex)
        { 
            error = ex.Message;
            // How to return the ex?
            // If the return type is a custom class, how to deal with it?
        }
     }
