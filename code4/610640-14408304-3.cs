    public class Group
    {
        public string Name;
        public int i;
        public static bool operator ==(Group a, Group b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Group a, Group b)
        {
            return !(a.Name == b.Name);
        }
        public override bool Equals(object obj)
        {
            var g = obj as Group;
            if (ReferenceEquals(this,g)) return true;
            return g.Name.Equals(Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
