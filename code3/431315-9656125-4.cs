    // Where possible, define equality on sealed types.
    // It gets messier otherwise...
    public sealed class Foo : IEquatable<Foo>
    {
        public static bool operator ==(Foo f1, Foo f2)
        {
            if (object.ReferenceEquals(f1, f2))
            {
                return true;
            }
            if (object.ReferenceEquals(f1, null) ||
                object.ReferenceEquals(f2, null))
            {
                return false;
            }
            // Perform actual equality check here
        }
        public override bool Equals(object other)
        {
            return this == (other as Foo);
        }
        public bool Equals(Foo other)
        {
            return this == other;
        }
    
        public static bool operator !=(Foo f1, Foo f2)
        {
            return !(f1 == f2);
        }
    
        public override int GetHashCode()
        {
            // Compute hash code here
        }
    }
