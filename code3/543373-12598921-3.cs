    public class Cmp1 : IEqualityComparer<YourClass>
    {
        #region IEqualityComparer<YourClass> Members
        public bool Equals(YourClass x, YourClass y)
        {
            return
                x.Prop1 == y.Prop1 && x.Prop3 == y.Prop3;
        }
        public int GetHashCode(YourClass obj)
        {
            int hCode = obj.Prop1.GetHashCode() ^ obj.Prop3.GetHashCode();
            return hCode.GetHashCode();
        }
        #endregion
    }
    // matched elements from both lists
    var r1 = l1.Intersect<YourClass>(l2, new Cmp1());
    // elements from l1 not in l2
    var r2 = l1.Except<YourClass>(l2, new Cmp1());
    // elements from l2 not in l1
    var r3 = l2.Except<YourClass>(l1, new Cmp1());
