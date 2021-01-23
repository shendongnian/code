    public class Person : IEquatable<Person>
    {    
     public string Name { get; set; }     
     public string BaseCode { get; set; }     
     public List<Location> Locations { get; set; } 
    
            public bool Equals(Person other)
            {
                if (Object.ReferenceEquals(other, null)) return false;
    
                if (Object.ReferenceEquals(this, other)) return true;
                return Name.Equals(other.Name) && BaseCode.Equals(other.BaseCode);
            }
    
            public override int GetHashCode()
            {
                int hashName = Name == null ? 0 : Name.GetHashCode();
                int hashBaseCode = BaseCode.GetHashCode();
                return hashName ^ hashBaseCode;
            }
    
    
    } 
