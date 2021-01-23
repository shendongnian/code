    try
    {
        MainEntryPoint();
    }
    catch (Exception exc)
    {
       System.Diagnostics.Debug.Print(exc.Message);  // get at entire error message w/ stacktrace
       System.Diagnostics.Debug.Print(exc.StackTrace);  // or just the stacktrace
    }
