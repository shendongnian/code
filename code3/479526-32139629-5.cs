        public static string GetWindowsProductKey()
        {
                var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                              RegistryView.Default);
                const string keyPath = @"Software\Microsoft\Windows NT\CurrentVersion";
                var digitalProductId = (byte[])key.OpenSubKey(keyPath).GetValue("DigitalProductId");
            var isWin8OrUp =
                (Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor >= 2)
                ||
                (Environment.OSVersion.Version.Major > 6);
            var productKey = isWin8OrUp ? DecodeProductKeyWin8AndUp(digitalProductId) : DecodeProductKey(digitalProductId);
            return productKey;
        }
