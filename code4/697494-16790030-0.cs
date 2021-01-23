    public class Comparer: IComparer<string>
    {
        public int Compare(IList<string> x, IList<string> y)
        {
            // base the comparison result on the first element in the respective lists
            // eg basically
            return x[0].CompareTo(y[0]);
        }
