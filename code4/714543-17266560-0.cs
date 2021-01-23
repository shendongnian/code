    public static bool SaveUser(string Database, string UserName, string UserPassword, string SecurityLevel)
    {
        bool recordSaved = false;
        try
        {
            // do your save
            recordSaved = true;
        }
        catch (Exception ex)
        {
           // Handle the exception (logging, etc)
        }
        return recordSaved;
    }
