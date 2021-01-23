    public class UtilVersionAttribute : Attribute
    {
        private readonly string _versionInfo;
    
        public UtilVersionAttribute(string versionInfo) { _versionInfo = versionInfo; }
    
        public string VersionInfo { get { return _versionInfo; } }
    }
