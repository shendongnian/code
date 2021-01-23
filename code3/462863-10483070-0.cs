    public class PersonComparer : IComparer<APerson>
    {
        public static readonly Default = new PersonEqualityComparer();
    }
    
    public class APerson : IComparable<APerson>
    {
        public int CompareTo(APerson other)
        {
            return PersonComparer.Default.Compare(this, other);
        }
    }
