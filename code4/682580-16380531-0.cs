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
           
           return ra.VendorName.Equals(this.VendorName) &&
                  ra.Name.Equals(this.Name) &&
                  ra.Version.Equals(this.Version);
    
        }
    
        public override int GetHashCode()
        {
    	    return VendorName.GetHashCode() ^ Name.GetHashCode() ^ Version.GetHashCode();
        }
    
    } 
