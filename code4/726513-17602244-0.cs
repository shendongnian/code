    public class NameClass : IEquatable<NameClass>
    {
        public NameClass(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    
        // implement IEquatable<NameClass>
        public bool Equals(NameClass other)
        {
            return (other != null) && (Name == other.Name);
        }
        // override Object.Equals(Object)
        public override bool Equals(object obj)
        {
            return Equals(obj as NameClass);
        }
    
        // override Object.GetHashCode()
        public override GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
