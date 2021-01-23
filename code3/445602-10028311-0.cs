    [Seriazable]
    public class Package {
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public Package() { }
    }
    
    
    [Seriazable]
    public class PrivatePackage : Package{
    
        public string List<Document> Documents { get; set; }
    
    }
    
    
    [Seriazable]
    public class PublicPackage : Package {
    
    
    }
    
    
    [WebMethod]
    public Package GetPackage(int Id);
    
    [WebMethod]
    public PublicPackage GetPublicPackage(int Id);
    
    [WebMethod]
    public PrivatePackage GetPublicPackage(int Id);
    
    
    [WebMethod]
    public List<PrivatePackage> FindPrivatePackage();
    
    [WebMethod]
    public List<PublicPackage> FindPublicPackage();
