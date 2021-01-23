    public class MyComparer : IEqualityComparer<YourClass>
    {
        #region IEqualityComparer<YourClass> Members
        public bool Equals(YourClass x, YourClass y)
        {
            return
                x.Prop1.Equals(y.Prop1) && x.Prop3.Equals(y.Prop3);
        }
        public int GetHashCode(YourClass obj)
        {
            int hCode = obj.Prop1.GetHashCode() ^ obj.Prop3.GetHashCode();
            return hCode.GetHashCode();
        }
        #endregion
    }
    // matched elements from both lists
    var r1 = l1.Intersect<YourClass>(l2, new MyComparer());
    // elements from l1 not in l2
    var r2 = l1.Except<YourClass>(l2, new MyComparer());
    // elements from l2 not in l1
    var r3 = l2.Except<YourClass>(l1, new MyComparer());
