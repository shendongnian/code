    public class Location : IEquatable<Location>
    {    
           public string Name { get; set; }     
	       public string BaseCode { get; set; 
    
            public bool Equals(Location other)
            {
                if (Object.ReferenceEquals(other, null)) return false;
    
                if (Object.ReferenceEquals(this, other)) return true;
                return BaseCode.Equals(other.BaseCode);
            }
    
            public override int GetHashCode()
            {
                return BaseCode.GetHashCode();
            }
    
    
    } 
