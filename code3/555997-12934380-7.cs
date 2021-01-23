    class ObjectArrayComparer : IEqualityComparer<Object[]>
    {
        public bool Equals(Object[] x, Object[] y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == null && y[i] == null) continue;
                if (x[i] == null || y[i] == null) return false;
                if (!x[i].Equals(y[i])) return false;
            }
            return true;
        }
        public int GetHashCode(Object[] obj)
        {
            int hash = 0;
            if (obj != null)
            {
                hash = (hash * 17) + obj.Length;
                foreach (Object o in obj)
                {
                    hash *= 17;
                    if (o != null) hash = hash + o.GetHashCode();
                }
            }
            return hash;
        }
    }
