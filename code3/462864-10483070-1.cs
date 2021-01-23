    public class PersonEqaulityComparer : IEqualityComparer<APerson>
    {
        public static readonly Default = new PersonEqualityComparer();
    }
    
    public class APerson : IEquatable<APerson>
    {
        public bool Equals(APerson other)
        {
            return PersonEqualityComparer.Default.Equals(this, other);
        }
    }
