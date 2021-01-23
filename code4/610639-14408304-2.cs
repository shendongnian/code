    public class Group 
    {
        public string Name;
            
        public static bool operator ==(Group a,Group b)
        {
            return a.Name == b.Name;
        }
        public static bool operator !=(Group a, Group b)
        {
            return a.Name != b.Name;
        }
        public override bool Equals(object obj)
        {
            return obj.Equals(Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
