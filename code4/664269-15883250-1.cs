    private static void WebBrowserVersionEmulation()
    {
        const string BROWSER_EMULATION_KEY = 
        @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        //
        // app.exe and app.vshost.exe
        String appname = Process.GetCurrentProcess().ProcessName + ".exe";
        //
        // Webpages are displayed in IE9 Standards mode, regardless of the !DOCTYPE directive.
        int value = 9999;
        //
        RegistryKey BrowserEmulationKey =
            Registry.CurrentUser.OpenSubKey(
              BROWSER_EMULATION_KEY, 
              RegistryKeyPermissionCheck.ReadWriteSubTree);
        if (BrowserEmulationKey == null)
        {
            BrowserEmulationKey = 
               Registry.CurrentUser.CreateSubKey(BROWSER_EMULATION_KEY);
        }
        if (BrowserEmulationKey != null)
        {
            BrowserEmulationKey.SetValue(appname, value, RegistryValueKind.DWord);
            BrowserEmulationKey.Close();
        }
    }
