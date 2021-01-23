    var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
    RegistryKey Regkey = null;
    try
    {
        int BrowserVer, RegVal;
        // get the installed IE version
        using (WebBrowser Wb = new WebBrowser())
            BrowserVer = Wb.Version.Major;
        // set the appropriate IE version
        if (BrowserVer >= 11)
            RegVal = 11001;
        else if (BrowserVer == 10)
            RegVal = 10001;
        else if (BrowserVer == 9)
            RegVal = 9999;
        else if (BrowserVer == 8)
            RegVal = 8888;
        else
            RegVal = 7000;
        //For 64 bit Machine 
        if (Environment.Is64BitOperatingSystem)
            Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
        else  //For 32 bit Machine 
            Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
        //If the path is not correct or 
        //If user't have priviledges to access registry 
        if (Regkey == null)
        {
            MessageBox.Show("Registry Key for setting IE WebBrowser Rendering Address Not found. Try run the program with administrator's right.");
            return;
        }
        string FindAppkey = Convert.ToString(Regkey.GetValue(appName));
        //Check if key is already present 
        if (FindAppkey == RegVal.ToString())
        {
            Regkey.Close();
            return;
        }
        Regkey.SetValue(appName, RegVal, RegistryValueKind.DWord);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Registry Key for setting IE WebBrowser Rendering failed to setup");
        MessageBox.Show(ex.Message);
    }
    finally
    {
        //Close the Registry 
        if (Regkey != null)
            Regkey.Close();
    }
