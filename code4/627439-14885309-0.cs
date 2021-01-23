    private Mutex mutex = new Mutex(false, "Test");
    
    public static bool SetAsposeLicense()
    {
        try
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(5))
            {
                throw new TimeoutException("Aspose license registration timed out.");
            }
            try
            {
                var objLic = new License();
                objLic.SetLicense(@"C:\Nivedita\License\Aspose.Cells.lic");
                return true;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return false;
        }
    }
