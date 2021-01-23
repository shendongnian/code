    public class CustomComparer : EqualityComparer<A>
    {
        public override int GetHashCode(A a)
        {
            int hCode = a.Pro1.GetHashCode() ^ a.Pro2.GetHashCode();
            return hCode.GetHashCode();
        }
    
        public override bool Equals(A a1, A a2)
        {
            return a1.Pro1.Equals(a2.Pro1) && a1.Pro2.Equals(a2.Pro2)
        }
    }
