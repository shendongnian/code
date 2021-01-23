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
                DoStuff();
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
    
        private static void RestartElevated()
        {
            String[] argumentsArray = Environment.GetCommandLineArgs();
            String argumentsLine = String.Empty;
    
            for (Int32 i = 1; i < argumentsArray.Length; ++i)
                argumentsLine += "\"" + argumentsArray[i] + "\" ";
    
            ProcessStartInfo info = new ProcessStartInfo();
    
            info.Arguments = argumentsLine.TrimEnd();
            info.CreateNoWindow = false;
            info.ErrorDialog = false;
            info.FileName = Application.ExecutablePath;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            info.Verb = "runas";
            info.WindowStyle = ProcessWindowStyle.Hidden; 
            info.WorkingDirectory = Environment.CurrentDirectory;
    
            try
            {
                Process.Start(info);
            }
            catch { return; }
    
            Application.Exit();
        }
    }
