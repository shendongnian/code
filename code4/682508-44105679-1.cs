    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Win32;
    namespace Test
    {  
    internal class Program
    {  
        public enum ProgramVersion
        {
            x86,
            x64
        }
        private static IEnumerable<string> GetRegisterSubkeys(RegistryKey registryKey)
        {
            return registryKey.GetSubKeyNames()
                    .Select(registryKey.OpenSubKey)
                    .Select(subkey => subkey.GetValue("DisplayName") as string);
        }
        private static bool CheckNode(RegistryKey registryKey, string applicationName, ProgramVersion? programVersion)
        {
            return GetRegisterSubkeys(registryKey).Any(displayName => displayName != null
                                                                      && displayName.Contains(applicationName)
                                                                      && displayName.Contains(programVersion.ToString()));
        }
        private static bool CheckApplication(string registryKey, string applicationName, ProgramVersion? programVersion)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
    
            if (key != null)
            {
                if (CheckNode(key, applicationName, programVersion))
                    return true;
                
                key.Close();
            }
            return false;
        }
        public static bool IsSoftwareInstalled(string applicationName, ProgramVersion? programVersion)
        {
            string[] registryKey = new [] {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
                @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
            };
            return registryKey.Any(key => CheckApplication(key, applicationName, programVersion));
        }
        private static void Main()
        {
            // Examples
            Console.WriteLine("Notepad++: " + IsSoftwareInstalled("Notepad++", null));
            Console.WriteLine("Notepad++(x86): " + IsSoftwareInstalled("Notepad++", ProgramVersion.x86));
            Console.WriteLine("Notepad++(x64): " + IsSoftwareInstalled("Notepad++", ProgramVersion.x64));
            Console.WriteLine("Microsoft Visual C++ 2009: " + IsSoftwareInstalled("Microsoft Visual C++ 2009", null));
            Console.WriteLine("Microsoft Visual C-- 2009: " + IsSoftwareInstalled("Microsoft Visual C-- 2009", null));
            Console.WriteLine("Microsoft Visual C++ 2013: " + IsSoftwareInstalled("Microsoft Visual C++ 2013", null));
            Console.WriteLine("Microsoft Visual C++ 2012 Redistributable (x86): " + IsSoftwareInstalled("Microsoft Visual C++ 2013", ProgramVersion.x86));
            Console.WriteLine("Microsoft Visual C++ 2012 Redistributable (x64): " + IsSoftwareInstalled("Microsoft Visual C++ 2013", ProgramVersion.x64));
            Console.ReadKey();
        }
    }
    }
