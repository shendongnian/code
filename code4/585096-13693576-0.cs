        public enum AppInstallType { msi, exe }
    
    public class Application
    {
        //Properties
        public string AppID { get; set; }
        public string AppName { get; set; }
        public string AppVer { get; set; }
        public string AppInstallArgs { get; set; }
        public AppInstallType InstallType;
        public string AppInstallerLocation { get; set; }
    }
    
    if(InstallType == AppInstallType.msi)
