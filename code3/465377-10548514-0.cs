    foreach (Building B in AllBldgs)
    {
        try
        {
            EnvBinRead.Close();
        }
        catch { }
        try
        {
            EnvBinWrite.Close();
        }
        catch { }
        try
        {
            BinRead.Close();
        }
        catch { }
        try
        {
            BinWrite.Close();
        }
        catch { }
    }
