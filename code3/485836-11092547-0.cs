    static void Main()
    {
        // Create a subkey named Test9999 under HKEY_CURRENT_USER.
        RegistryKey test9999 = 
            Registry.CurrentUser.CreateSubKey("Test9999");
        // Create two subkeys under HKEY_CURRENT_USER\Test9999. The
        // keys are disposed when execution exits the using statement.
        using(RegistryKey 
            testName = test9999.CreateSubKey("TestName"),
            testSettings = test9999.CreateSubKey("TestSettings"))
        {
            // Create data for the TestSettings subkey.
            testSettings.SetValue("Language", "French");
            testSettings.SetValue("Level", "Intermediate");
            testSettings.SetValue("ID", 123);
        }
    }
