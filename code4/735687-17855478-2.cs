    public class MyComparer : IEqualityComparer<MyType>
    {
        public bool Equals(MyType x, MyType y)
        {
            return x.Name.Equals(y.Name);
        }
        public int GetHashCode(MyType obj)
        {
            return obj.Name == null ? 0 : obj.Name.GetHashCode();
        }
    }
