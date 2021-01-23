    public class MyObjectEqualityComparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.TypeID == y.TypeID;
        }
        public int GetHashCode(MyObject obj)
        {
            return obj.TypeID; //Already an int
        }
    }
