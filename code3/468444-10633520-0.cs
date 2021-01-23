    var intersectionList = foo.Intersect(bar, new ThisClassEqualityComparer()).ToList();
    class ThisClassEqualityComparer : IEqualityComparer<ThisClass>
    {
        public bool Equals(ThisClass b1, ThisClass b2)
        {
            return b1.a == b2.a;
        }
        public int GetHashCode(Box bx)
        {
           // To ignore to compare hashcode, please consider this.
           // I would like to force Equals() to be called
           return 0;
        }
    }
