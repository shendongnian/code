    using System;
    using System.Diagnostics;
    using Microsoft.Win32;
    class Program
    {
        static void Main(string[] args)
        {
            object path;
            path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
            if (path != null)
                Console.WriteLine("Chrome: " + FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);
            path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\firefox.exe", "", null);
            if (path != null)
                Console.WriteLine("Firefox: " + FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);
        }
    }
