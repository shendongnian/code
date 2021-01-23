    private class LambdaComparer<T, U> : IEqualityComparer<T>
    {
        private Func<T, U> selector;
 
        public LambdaComparer(Func<T, U> selector)
        {
            this.selector = selector;
        }
        public bool Equals(T x, T y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return EqualityComparer<U>.Default.Equals(selector(x), selector(y));
        }
        public int GetHashCode(T obj)
        {
            if (obj == null) return 0;
            return EqualityComparer<U>.Default.GetHashCode(selector(obj));
        }
    }
    var inList1ButNot2 = List1.IDList.Except(
        List2.IDList,
        new LambdaComparer<ClassWithID, int>(w => w.ID));
