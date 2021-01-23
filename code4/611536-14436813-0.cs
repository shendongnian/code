    public struct Key : IComparable<Key>
    {
        public String Name;
        public Roles Role;
        public Period Period;
        public int CompareTo(Key other)
        {
            var c = String.Compare(Name, other.Name, StringComparison.Ordinal);
            if (c != 0) return c;
            c = Role.CompareTo(other.Role);
            if (c != 0) return c;
            return Period.CompareTo(other.Period);
        }
    }
