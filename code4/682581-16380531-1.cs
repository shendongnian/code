    public struct RegistryApp
    {
        public string VendorName;
        public string Name;
        public string Version;
    
        public override bool Equals(object obj) 
        {
           if (!(obj is MyStruct))
              return false;
    
           RegistryApp ra = (RegistryApp) obj;
           
           return ra.VendorName == this.VendorName &&
                  ra.Name == this.Name &&
                  ra.Version == this.Version;
    
        }
    
        public override int GetHashCode()
        {
    	    return VendorName.GetHashCode() ^ Name.GetHashCode() ^ Version.GetHashCode();
        }
    
    } 
