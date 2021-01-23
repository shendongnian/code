    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            if(x != null && y != null)
                return x.FullName.CompareTo(y.FullName);
            else if(x != null)
                return x.FullName.CompareTo(null);
            else if(y != null)
                return y.FullName.CompareTo(null);
            else
                return 0;
        }
    }
