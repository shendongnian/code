        public bool IsInstalled()
        {
            RegistryKey registryBase = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, string.Empty);
            if (registryBase != null)
            {
                return registryBase.OpenSubKey("Software\\Microsoft\\ReportViewer\\v2.0.50727") != null;
            }
            return false;
        }
