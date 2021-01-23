    public class MyObject :  IEquatable <MyObject >
    {
        public string Name { get; set; }
    
        public string Value { set; get; }
    
        public Guid ID { get; set; }
        
        public bool Equals(MyObject other)
        {
        //Check whether the compared object is null. 
        if (Object.ReferenceEquals(other, null)) return false;
        //Check whether the compared object references the same data. 
        if (Object.ReferenceEquals(this, other)) return true;
        //Check whether the objects properties are equal. 
        return Name.Equals(other.Name) && Value.Equals(other.Value) && ID.Equals(other.ID);
        }
        public override int GetHashCode()
        {
        //Get hash code for the Name field if it is not null. 
        int hashName = Name == null ? 0 : Name.GetHashCode();
        //Get hash code for the Value field. 
        int hashCode = Value == null ? 0 : Value .GetHashCode();
        //Get hash code for the IDfield. 
        int hashID =  ID.GetHashCode();
        //Calculate the hash code for the entire object. 
        return hashName  ^ hashCode ^ hashId;
        }
    }
