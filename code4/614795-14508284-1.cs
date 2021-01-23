    // useful class
    public class MyStuff 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MyValue { get; set; }
 
        public override int GetHashCode()
        {
            return Id;
        }
 
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (MyStuff)) return false;
 
            var other = obj as MyStuff;
 
            return (other.Id == Id
                && other.MyValue == MyValue
                && other.Equals(other.Name, Name));
            // use .Equals() here to compare objects; == for Value types
 
            // alternative weak Equals() for value objects:
            // return (other.MyValue == MyValue && other.Equals(other.Name, Name) );
        }
    }
