    public class PossibleMatchComparer: IComparer<PossibleMatch>
    {
        public int Compare(PossibleMatch x, PossibleMatch y)
        {
            if (x.StoreIds.Count < y.StoreIds.Count) return -1;
            if (x.StoreIds.Count > y.StoreIds.Count) return 1;
            return y.OrderLineIds.Count - x.OrderLineIds.Count;
        }
    }
