    try
    {
       System.Diagnostics.Process Client = System.Diagnostics.Process.GetProcessesByName("Client")[0];
    }
    catch (IndexOutOfRangeException e)
    {
        System.Diagnostics.Process Client = null;
    }
