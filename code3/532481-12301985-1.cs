    public class ListCountComparer : IComparer<IList> {
        public int Compare(IList x, IList y) {
            return x.Count.CompareTo(y.Count);
        }
    }
