    class FirstItemComparer : IEqualityComparer<List<string>> {
        public bool Equals(List<string> a, List<string> b) {
            return a[0] == b[0];
        }
    
        public int GetHashCode(List<string> l) {
            return l[0].GetHashCode();
        }
    }
    ...
    items.Distinct(new FirstItemComparer())
