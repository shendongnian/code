    public class Products : IEquatable<Products>
    {
        public string Name { get; set; }  //your properties
    
        public bool Equals(Products other)
        {
    
            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(other, null)) return false;
    
            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;
    
            //Check whether the products' properties are equal. 
            return Name.Equals(other.Name);
        }
    
        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 
    
        public override int GetHashCode()
        {
    
            //Get hash code for the Name field if it is not null. 
            int hashProductName = Name == null ? 0 : Name.GetHashCode();  
            
    
            //Calculate the hash code for the product. 
            return hashProductName ;
        }
    }
