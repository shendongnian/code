    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Threading;
    using Microsoft.Win32;
    using System.Diagnostics;
    namespace ClientUI
    {
        static class Program
        {
            static Mutex mutex = new System.Threading.Mutex(false, "jMutex");
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
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
                    var targetApplication = Process.GetCurrentProcess().ProcessName + ".exe";
                    int ie_emulation = 11999;
                    try
                    {
                        string tmp = Properties.Settings.Default.ie_emulation;
                        ie_emulation = int.Parse(tmp);
                    }
                    catch { }
                    SetIEVersioneKeyforWebBrowserControl(targetApplication, ie_emulation);
                    Application.Run(new MainForm());
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
                    // if user doesn't have privileges to access the registry
                    if (Regkey == null)
                    {
                        MessageBox.Show("Application FEATURE_BROWSER_EMULATION Failed - Registry key Not found");
                        return;
                    }
                    string FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                    // Check if key is already present
                    if (FindAppkey == ieval.ToString())
                    {
                        MessageBox.Show("Application FEATURE_BROWSER_EMULATION already set to " + ieval);
                        Regkey.Close();
                        return;
                    }
                    // If key is not present or different from desired, add/modify the key , key value
                    Regkey.SetValue(appName, unchecked((int)ieval), RegistryValueKind.DWord);
                    // Check for the key after adding
                    FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                    if (FindAppkey == ieval.ToString())
                    {
                        MessageBox.Show("Application FEATURE_BROWSER_EMULATION changed to " + ieval + "; changes will be visible at application restart");
                    }
                    else
                    {
                        MessageBox.Show("Application FEATURE_BROWSER_EMULATION setting failed; current value is  " + ieval);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Application FEATURE_BROWSER_EMULATION setting failed; " + ex.Message);
                }
                finally
                {
                    //Close the Registry
                    if (Regkey != null) Regkey.Close();
                }
            }
        }
    }
