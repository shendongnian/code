    foreach (Building B in AllBldgs)
    {
        try
        {
            EnvBinRead.Close();
        }
        catch (Exception exp)
        { 
            Console.WriteLine("Closing EnvBinRead failed!" + exp.ToString());
        }
        try
        {
            EnvBinWrite.Close();
        }
        catch (Exception exp)
        { 
            Console.WriteLine("Closing EnvBinWrite failed!" + exp.ToString());
        }
        try
        {
            BinRead.Close();
        }
        catch (Exception exp)
        { 
            Console.WriteLine("Closing BinRead failed!" + exp.ToString());
        }
        try
        {
            BinWrite.Close();
        }
        catch (Exception exp)
        { 
            Console.WriteLine("Closing BinWrite failed!" + exp.ToString());
        }
    }
