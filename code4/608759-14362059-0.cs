    static bool CheckUser(string userName, string password) 
    {
        var adSettings = ConfigurationManager.ConnectionStrings["ActiveDirectory"];
        if (adSettings == null ||
            string.IsNullOrWhiteSpace(adSettings.ConnectionString))
        {
            return false;
        }
        try
        {
            using (var de = new DirectoryEntry(adSettings.ConnectionString, userName, password))
            {
                // This should throw an exception if the password is wrong
                object nativeObject = de.NativeObject;
            }
        }
        catch (DirectoryServicesCOMException)
        {
            // Wrong password
            return false;
        }
        catch (System.Runtime.InteropServices.COMException)
        {
            // Can't connect
            return false;
        }
        
        return true;
    }
