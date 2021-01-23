    internal static class RegistryHelper
    {
        private const string UpgradeCodeRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UpgradeCodes";
        private static readonly int[] GuidRegistryFormatPattern = new[] { 8, 4, 4, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static Guid? GetUpgradeCode(Guid productCode)
        {
            // Convert the product code to the format found in the registry
            var productCodeSearchString = ConvertToRegistryFormat(productCode);
            // Open the upgrade code registry key
            var upgradeCodeRegistryRoot = Registry.LocalMachine.OpenSubKey(UpgradeCodeRegistryKey);
            if (upgradeCodeRegistryRoot == null)
                return null;
            // Iterate over each sub-key
            foreach (var subKeyName in upgradeCodeRegistryRoot.GetSubKeyNames())
            {
                var subkey = upgradeCodeRegistryRoot.OpenSubKey(subKeyName);
                if (subkey == null)
                    continue;
                // Check for a value containing the product code
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
        private static string ConvertToRegistryFormat(Guid productCode)
        {
            return Reverse(productCode, GuidRegistryFormatPattern);
        }
        private static Guid ConvertFromRegistryFormat(string upgradeCode)
        {
            if (upgradeCode == null || upgradeCode.Length != 32)
                throw new FormatException("Product code was in an invalid format");
            upgradeCode = Reverse(upgradeCode, GuidRegistryFormatPattern);
            return Guid.Parse(upgradeCode);
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
    }
