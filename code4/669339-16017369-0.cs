        class MyComparer<T> : IEqualityComparer<T> where T : YourClass
        {
            public bool Equals(T x, T y)
            {
                return x.Id.Equals(y.Id);
            }
            public int GetHashCode(T obj)
            {
                return obj.Id.GetHashCode();
            }
        }
