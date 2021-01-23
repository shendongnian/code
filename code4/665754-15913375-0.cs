    try
    {
       // your code
    }
    catch (Exception e)
    {
       System.IO.File.WriteAllText(@"Z:\err.txt", e.ToString());
    }
