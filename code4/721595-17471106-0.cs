    public interface IGeneralInfo 
    {
        String Id { get; set; }
        String Name { get; set; }
    }
    
    public interface ISecureInfo
        String Password { get; set; }
    }
    
    
    public class User : IGeneralInfo, ISecureInfo
    {
        // Implementation of IGeneralInfo
        public String Id { get; set; }
        public String Name { get; set; }
        // Implementation of ISecureInfo
        public String Password { get; set; }
    }
