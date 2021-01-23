    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    internal static class RegistryHelper
    {
        private const string UpgradeCodeRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UpgradeCodes";
    
        private static readonly int[] GuidRegistryFormatPattern = new[] { 8, 4, 4, 2, 2, 2, 2, 2, 2, 2, 2 };
    
    
        public static Guid? GetProductCode(Guid upgradeCode)
        {
            // Convert the product code to the format found in the registry
            var productCodeSearchString = ConvertToRegistryFormat(upgradeCode);
    
            // Open the upgrade code registry key
            var upgradeCodeRegistryRoot = GetRegistryKey(Path.Combine(UpgradeCodeRegistryKey, productCodeSearchString));
    
            if (upgradeCodeRegistryRoot == null)
                return null;
    
            var uninstallCode = upgradeCodeRegistryRoot.GetValueNames().FirstOrDefault();
            if (string.IsNullOrEmpty(uninstallCode))
            {
                return null;
            }
    
            // Convert it back to a Guid
            return ConvertFromRegistryFormat(uninstallCode);
        }
    
    
        
    
    
        private static string ConvertToRegistryFormat(Guid code)
        {
            return Reverse(code, GuidRegistryFormatPattern);
        }
    
        private static Guid ConvertFromRegistryFormat(string code)
        {
            if (code == null || code.Length != 32)
                throw new FormatException("Product code was in an invalid format");
    
            code = Reverse(code, GuidRegistryFormatPattern);
    
            return Guid.Parse(code);
        }
    
        private static string Reverse(object value, params int[] pattern)
        {
            // Strip the hyphens
            var inputString = value.ToString().Replace("-", "");
    
            var returnString = new StringBuilder();
    
            var index = 0;
    
            // Iterate over the reversal pattern
            foreach (var length in pattern)
            {
                // Reverse the sub-string and append it
                returnString.Append(inputString.Substring(index, length).Reverse().ToArray());
    
                // Increment our posistion in the string
                index += length;
            }
    
            return returnString.ToString();
        }
    
        static RegistryKey GetRegistryKey(string registryPath)
        {
            var hklm64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var registryKey64 = hklm64.OpenSubKey(registryPath);
            if (((bool?)registryKey64?.GetValueNames()?.Any()).GetValueOrDefault())
            {
                return registryKey64;
            }
    
            var hklm32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            return hklm32.OpenSubKey(registryPath);
        }
    }
