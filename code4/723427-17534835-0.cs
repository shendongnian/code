    using WindowsInstaller;
    
    ...
        public static class MyMsiLib
        {
            public static void Uninstall(string productCode)
            {
                
                Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
                Installer installer = (Installer)Activator.CreateInstance(type);
                installer.UILevel=msiUILevelNone;
                installer.ConfigureProduct(productCode, 0, msiInstallStateAbsent);
            }
        }
    }
