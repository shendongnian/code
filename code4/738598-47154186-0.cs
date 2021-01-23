    class RegistryHelper
    {
        private const string UpgradeCodeRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UpgradeCodes";
        private const string UninstallRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        private static readonly int[] GuidRegistryFormatPattern = new[] { 8, 4, 4, 2, 2, 2, 2, 2, 2, 2, 2 };
      
        public static string To64BitPath(string path)
        { 
            return path.Replace("SOFTWARE\\Microsoft", "SOFTWARE\\WOW6432Node\\Microsoft");
        }
        private static RegistryKey GetLocalMachineRegistryKey(string path)
        {
            return RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, string.Empty).OpenSubKey(path);
        }
        public static IEnumerable<Guid> GetUpgradeCodes()
        {
            var list = new List<Guid>();
            var key = GetRegistryKey(UpgradeCodeRegistryKey);
            if (key != null)
            {
                list.AddRange(key.GetSubKeyNames().Select(ConvertFromRegistryFormat));
            }
            return list;
        }
        public static Guid? GetProductCode(Guid upgradeCode)
        {
            // Convert the product upgradeCode to the format found in the registry
            var productCodeSearchString = ConvertToRegistryFormat(upgradeCode);
            // Open the upgradeCode upgradeCode registry key
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
        public static string ConvertToRegistryFormat(Guid code)
        {
            return Reverse(code, GuidRegistryFormatPattern);
        }
        private static Guid ConvertFromRegistryFormat(string code)
        {
            if (code == null || code.Length != 32)
                throw new FormatException("Product upgradeCode was in an invalid format");
            code = Reverse(code, GuidRegistryFormatPattern);
            return new Guid(code);
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
            var registryKey64 = GetLocalMachineRegistryKey(To64BitPath(registryPath));
            if (((bool?)registryKey64?.GetValueNames()?.Any()).GetValueOrDefault())
            {
                return registryKey64;
            }
            
            return GetLocalMachineRegistryKey(registryPath);
        }
        
        public static Guid? GetUpgradeCode(Guid productCode)
        {
            var productCodeSearchString = ConvertToRegistryFormat(productCode);
            var upgradeCodeRegistryRoot = GetRegistryKey(UpgradeCodeRegistryKey);
            if (upgradeCodeRegistryRoot == null)
            {
                return null;
            }
            // Iterate over each sub-key
            foreach (var subKeyName in upgradeCodeRegistryRoot.GetSubKeyNames())
            {
                var subkey = upgradeCodeRegistryRoot.OpenSubKey(subKeyName);
                if (subkey == null)
                    continue;
                // Check for a value containing the product upgradeCode
                if (subkey.GetValueNames().Any(s => s.IndexOf(productCodeSearchString, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    // Extract the name of the subkey from the qualified name
                    var formattedUpgradeCode = subkey.Name.Split('\\').LastOrDefault();
                    // Convert it back to a Guid
                    return ConvertFromRegistryFormat(formattedUpgradeCode);
                }
            }
            return null;
        }
    }
