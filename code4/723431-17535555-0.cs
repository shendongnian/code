    using Microsoft.Deployment.WindowsInstaller;
    
    public static void Uninstall( string productCode)
    {
        Installer.ConfigureProduct(productCode, 0, InstallState.Absent, "REBOOT=\"R\" /l*v uninstall.log");
    }
