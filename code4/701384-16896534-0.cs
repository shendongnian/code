    public static class SelfInstaller
    {
        private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;
        public static bool InstallMyService()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { _exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool UninstallMyService()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/u", _exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool isInstalled(string serviceName)
        {
             var serviceExists = ServiceController.GetServices().Any(s => s.ServiceName == serviceName);
             if (serviceExists == null) return false;
             return true;
        }
    }
