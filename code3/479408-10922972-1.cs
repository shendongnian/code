    class ListComparer<T> : IEqualityComparer<List<T>> {
        public bool Equals(List<T> a, List<T> b) {
            if (a.Count != b.Count)
                return false;
    
            for (int i = 0; i < a.Count; i++)
                if (! a[i].Equals(b[i])
                    return false;
    
            return true;
        }
    
        public int GetHashCode(List<T> a) {
            int ret = 11;
            unchecked {
                foreach (var x in a)
                    ret = ret * 17 + x.GetHashCode();
            }
            return ret;
        }
    }
