    internal static class BasicServiceInstaller
    {
        public static void Install(string serviceName)
        {
            CreateInstaller(serviceName).Install(new Hashtable());
        }
        public static void Uninstall(string serviceName)
        {
            CreateInstaller(serviceName).Uninstall(null);
        }
        private static Installer CreateInstaller(string serviceName)
        {
            var installer = new TransactedInstaller();
            installer.Installers.Add(new ServiceInstaller
            {
                ServiceName = serviceName,
                DisplayName = serviceName,
                StartType = ServiceStartMode.Manual
            });
            installer.Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            });
            var installContext = new InstallContext(
                serviceName + ".install.log", null);
            installContext.Parameters["assemblypath"] =
                Assembly.GetEntryAssembly().Location;
            installer.Context = installContext;
            return installer;
        }
    }
