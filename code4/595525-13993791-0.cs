    try
    {
        Database db = DatabaseFactory.CreateDatabase();
        ...
    }
    catch(Exception ex)
    {
        // this will dump to the output window in VS when running a Debug build
        System.Diagnostics.Debug.WriteLine(ex);
        ...
    }
