    System.Globalization.CultureInfo before = System.Threading.Thread.CurrentThread.CurrentCulture;
    try
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                        
        string timestr = DateTime.Now.ToString();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        System.Threading.Thread.CurrentThread.CurrentUICulture = before;
    }
