    private static object s_lock = new object();
    public static bool SetAsposeLicense()
    {
        if (Monitor.TryEnter(s_lock, TimeSpan.FromSeconds(5)))
        {
            try 
            {
                return SetLicenseInternal(); 
            }
            finally 
            {
                Monitor.Exit(s_lock);
            }
        }
        return SetLicenseInternal(); 
    }
    public static bool SetLicenseInternal()
    {
        try
        {
            var objLic = new License();
            objLic.SetLicense(@"C:\Nivedita\License\Aspose.Cells.lic");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return false;
        }
    }
