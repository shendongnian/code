    class MyComparer<T> : IEqualityComparer<T> where T : SelectListItem
    {
        public bool Equals(T x, T y)
        {
            return x.Value == y.Value ;
        }
        public int GetHashCode(T obj)
        {
            return obj.Id.GetHashCode();
        }
    }
