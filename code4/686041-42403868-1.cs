    string userName = "domain\user";
    string password = "whatever";
    string KEY_STR = "SomeSubKey\\ASubKeyToThat";
    WindowsImpersonationContext adminContext = Impersonation.getWic(userName, password);
    if (adminContext != null)
    {
        try
        {
           RegistryKey key = Registry.CurrentUser.OpenSubKey(KEY_STR, true);
           key.SetValue("State", 0x60001);
        }
        catch (Exception ex)
        {
            Console.Out.WriteLine("\nUnable to set registry value:\n\t" + ex.Message);
            Impersonation.endImpersonation();
            adminContext.Undo();
        }
        finally
        {
            Impersonation.endImpersonation();
            // The above line does this --            
            //if (tokenHandle != IntPtr.Zero) CloseHandle(tokenHandle);
            adminContext.Undo();
        }
    }
