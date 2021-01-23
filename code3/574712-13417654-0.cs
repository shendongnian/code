    public class XComparer: IEqualityComparer<X>
    {
        public bool Equals(X x1, X x2)
        {
            return x1.ID == x2.ID;
        }
        public int GetHashCode(X x)
        {
            return x.ID.GetHashCode();
        }
    }
