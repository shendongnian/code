    using System.Collections;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Diagnostics;
    
    namespace YourNamespace
    {
        [RunInstaller(true)]
        public class AddFirewallExceptionInstaller : Installer
        {
            protected override void OnAfterInstall(IDictionary savedState)
            {
                base.OnAfterInstall(savedState);
    
                OpenFirewallForProgram("YourExe.exe", "You program name for display");
            }
    
            private static void OpenFirewallForProgram(string exeFileName, string displayName)
            {
                var proc = Process.Start(
                    new ProcessStartInfo
                        {
                            FileName = "netsh",
                            Arguments =
                                string.Format(
                                    "firewall add allowedprogram program=\"{0}\" name=\"{1}\" profile=\"ALL\"",
                                    exeFileName, displayName),
                            WindowStyle = ProcessWindowStyle.Hidden
                        });
                proc.WaitForExit();
            }
        }
    }
