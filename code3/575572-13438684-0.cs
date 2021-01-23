    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Code { get; set; }
    
        public bool Equals(Person other)
        {
    
            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(other, null)) return false;
    
            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;
    
            //Check whether the person' properties are equal. 
            return Code.Equals(other.Code) && Name.Equals(other.Name);
        }
    
        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 
    
        public override int GetHashCode()
        {
    
            //Get hash code for the Name field if it is not null. 
            int hashPersonName = Name == null ? 0 : Name.GetHashCode();
    
            //Get hash code for the Code field. 
            int hashPersonCode = Code.GetHashCode();
    
            //Calculate the hash code for the person. 
            return hashPersonName ^ hashPersonCode;
        }
    }
    var distinctPersons = plst.Distinct().ToList();
