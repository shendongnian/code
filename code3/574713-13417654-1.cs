    public class XComparer: IEqualityComparer<X>
    {
        public bool Equals(X x1, X x2)
        {
            if (object.ReferenceEquals(x1, x2))
                return true;
            if (x1 == null || x2 == null)
                return false;
            return x1.ID.Equals(x2.ID);
        }
        public int GetHashCode(X x)
        {
            return x.ID.GetHashCode();
        }
    }
