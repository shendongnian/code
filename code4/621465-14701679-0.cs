    public class MyComparer : IComparer<Tuple<DateTime, double>>
    {
        public int Compare(Tuple<DateTime, double> x, Tuple<DateTime, double> y)
        {
            return x.Item1.CompareTo(y.Item1);
        }
    }
