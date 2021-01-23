    class StringListComparer : IComparer<List<string>>
    {
        public int Compare(List<string> x, List<string> y)
        {
            int minLength = Math.Min(x.Count, y.Count);
            for (int i = 0; i < minLength; i++) {
                int comp = x[i].CompareTo(y[i]);
                if (comp != 0) {
                    return comp;
                }
            }
            return x.Count.CompareTo(y.Count);
        }
    }
