    // Except gives you the items in the first set but not the second
            var equalityComparer = new MyClassEqualityComparer();
            var InList1ButNotList2 = List1.Except(List2, equalityComparer);
            var InList2ButNotList1 = List2.Except(List1, equalityComparer);
    // Intersect gives you the items that are common to both lists    
            var InBothLists = List1.Intersect(List2);
    public class MyClass
    {
        public int i;
        public int j;
    }
    class MyClassEqualityComparer : IEqualityComparer<MyClass>
    {
        public bool Equals(MyClass x, MyClass y)
        {
            return x.i == y.i &&
                   x.j == y.j;
        }
        public int GetHashCode(MyClass obj)
        {
            unchecked
            {
                if (obj == null)
                    return 0;
                int hashCode = obj.i.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.i.GetHashCode();
                return hashCode;
            }
        }
    }
