    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Windows.Forms;
    
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            if (!IsAdmin() && IsWindowsVistaOrHigher())
                RestartElevated();
            else
                AddToStartup(true);
        }
    
        private static Boolean IsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
    
            if (identity != null)
                return (new WindowsPrincipal(identity)).IsInRole(WindowsBuiltInRole.Administrator);
    
            return false;
        }
    
        private static Boolean IsWindowsVistaOrHigher()
        {
            OperatingSystem os = Environment.OSVersion;
            return ((os.Platform == PlatformID.Win32NT) && (os.Version.Major >= 6));
        }
    
        private static void AddToStartup(Boolean targetEveryone)
        {
            try
            {
                Environment.SpecialFolder folder = ((targetEveryone && IsWindowsVistaOrHigher()) ? Environment.SpecialFolder.CommonStartup : Environment.SpecialFolder.Startup);
                String fileDestination = Path.Combine(Environment.GetFolderPath(folder), Path.GetFileName(Application.ExecutablePath));
    
                if (!File.Exists(fileDestination))
                    File.Copy(Application.ExecutablePath, fileDestination);
            }
            catch { }
    
            try
            {
                using (RegistryKey main = (targetEveryone ? Registry.LocalMachine : Registry.CurrentUser))
                {
                    using (RegistryKey key = main.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        String fileName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
    
                        if (key.GetValue(fileName) == null)
                            key.SetValue(fileName, Application.ExecutablePath);
                    }
                }
            }
            catch { }
        }
    
        private static void RestartElevated()
        {
            String[] argumentsArray = Environment.GetCommandLineArgs();
            String argumentsLine = String.Empty;
    
            for (Int32 i = 1; i < argumentsArray.Length; ++i)
                argumentsLine += "\"" + argumentsArray[i] + "\" ";
    
            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = argumentsLine.TrimEnd();
            info.FileName = Application.ExecutablePath;
            info.UseShellExecute = true;
            info.Verb = "runas";
            info.WorkingDirectory = Environment.CurrentDirectory;
    
            try
            {
                Process.Start(info);
            }
            catch { return; }
    
            Application.Exit();
        }
    }
