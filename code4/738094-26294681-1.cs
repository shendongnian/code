        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                // Another application instance is running
                return;
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var targetApplication = Process.GetCurrentProcess().ProcessName  + ".exe";
                int ie_emulation = 10000;
                try
                {
                    string tmp = Properties.Settings.Default.ie_emulation;
                    ie_emulation = int.Parse(tmp);
                }
                catch { }
                SetIEVersioneKeyforWebBrowserControl(targetApplication, ie_emulation);
                m_webLoader = new FormMain();
                Application.Run(m_webLoader);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        private static void SetIEVersioneKeyforWebBrowserControl(string appName, int ieval)
        {
            RegistryKey Regkey = null;
            try
            {
                Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                // If the path is not correct or
                // if user haven't privileges to access the registry
                if (Regkey == null)
                {
                    YukLoggerObj.logWarnMsg("Application FEATURE_BROWSER_EMULATION Failed - Registry key Not found");
                    return;
                }
                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                // Check if key is already present
                if (FindAppkey == "" + ieval)
                {
                    YukLoggerObj.logInfoMsg("Application FEATURE_BROWSER_EMULATION already set to " + ieval);
                    Regkey.Close();
                    return;
                }
                // If a key is not present or different from desired, add/modify the key, key value
                Regkey.SetValue(appName, unchecked((int)ieval), RegistryValueKind.DWord);
                // Check for the key after adding
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                if (FindAppkey == "" + ieval)
                    YukLoggerObj.logInfoMsg("Application FEATURE_BROWSER_EMULATION changed to " + ieval + "; changes will be visible at application restart");
                else
                    YukLoggerObj.logWarnMsg("Application FEATURE_BROWSER_EMULATION setting failed; current value is  " + ieval);
            }
            catch (Exception ex)
            {
                YukLoggerObj.logWarnMsg("Application FEATURE_BROWSER_EMULATION setting failed; " + ex.Message);
            }
            finally
            {
                // Close the Registry
                if (Regkey != null)
                    Regkey.Close();
            }
        }
