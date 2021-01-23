    public class NameClass
    {
        public NameClass(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public override bool Equals(object obj)
        {
            var other = obj as NameClass;
            return other != null && other.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
