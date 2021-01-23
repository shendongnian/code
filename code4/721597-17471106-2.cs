    public interface IGeneralInfo 
    {
        String Id { get; set; }
        String Name { get; set; }
    }
    public class GeneralInfo : IGeneralInfo
    {
        public String Id { get; set; }
        public String Name { get; set; }
    }
    
    public interface ISecureInfo
        String Password { get; set; }
    }
    public class SecureInfo : IGeneralInfo
    {
        public String Password { get; set; }
    }
    
    public class User : IGeneralInfo, ISecureInfo
    {
        private GeneralInfo generalInfo = new GeneralInfo();
        private SecureInfo secureInfo = new SecureInfo();
        public String Id { 
            get { return generalInfo.Id; }
            set { generalInfo.Id = value; } 
        }
        public String Name { 
            get { return generalInfo.Name; }
            set { generalInfo.Name = value; } 
        }
        public String Password { 
            get { return secureInfo.Password; }
            set { secureInfo.Password = value; } 
        }
    }
