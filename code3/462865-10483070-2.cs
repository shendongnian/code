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
        public override bool Equals(object other)
        {
            return ((IEquatable<APerson>)this).Equals(other as APerson);
        }
        public override int GetHashCode()
        {
            return PersonEqualityComparer.Default.GetHashCode(this);
        }
    }
