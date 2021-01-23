    private void Form1_Load(object sender, EventArgs e)
    {
    
        var appName = Process.GetCurrentProcess().ProcessName + ".exe";
        SetIE8KeyforWebBrowserControl(appName);
    }
    private void SetIE8KeyforWebBrowserControl(string appName)
    {
        RegistryKey Regkey = null;
        try
        {
            //For 64 bit Machine 
            if (Environment.Is64BitOperatingSystem)
                Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
            else  //For 32 bit Machine 
                Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
            //If the path is not correct or 
            //If user't have priviledges to access registry 
            if (Regkey == null)
            {
                MessageBox.Show("Application Settings Failed - Address Not found");
                return;
            }
            string FindAppkey = Convert.ToString(Regkey.GetValue(appName));
            //Check if key is already present 
            if (FindAppkey == "8000")
            {
                MessageBox.Show("Required Application Settings Present");
                Regkey.Close();
                return;
            }
            //If key is not present add the key , Kev value 8000-Decimal 
            if (string.IsNullOrEmpty(FindAppkey))
                Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);
            //check for the key after adding 
            FindAppkey = Convert.ToString(Regkey.GetValue(appName));
            if (FindAppkey == "8000")
                MessageBox.Show("Application Settings Applied Successfully");
            else
                MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Application Settings Failed");
            MessageBox.Show(ex.Message);
        }
        finally
        {
            //Close the Registry 
            if (Regkey != null)
                Regkey.Close();
        }
    }
