    public void setIEcomp()
        {
            String appname = Process.GetCurrentProcess().ProcessName+".exe";
            RegistryKey RK8 = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION",RegistryKeyPermissionCheck.ReadWriteSubTree);            
            int value9 = 9999;
            int value8 = 8888;
            Version ver = webBrowser1.Version;
            int value = value9;
            try
            {
                string[] parts = ver.ToString().Split('.');
                int vn = 0;
                int.TryParse(parts[0], out vn);
                if (vn != 0)
                {
                    if (vn == 9)
                        value = value9;
                    else
                        value = value8;
                }
            }
            catch
            {
                value = value9;
            }
            //Setting the key in LocalMachine
            if (RK8 != null)
            {
                try
                {
                    RK8.SetValue(appname, value, RegistryValueKind.DWord);
                    RK8.Close();
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }
