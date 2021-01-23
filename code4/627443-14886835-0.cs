    static object s_lock = new object();
    public static bool SetAsposeLicense()
    {
        try
        {
            lock (s_lock)
            {
                var objLic = new License();
                objLic.SetLicense(@"C:\Nivedita\License\Aspose.Cells.lic");
            }
            return true;
        }
        catch(Exception ex)
        {
               Console.WriteLine(ex.StackTrace);               
               return false;
        }
    }       
