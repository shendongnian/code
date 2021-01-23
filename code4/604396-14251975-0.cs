    public class NullableDateTimeComparer : IComparer<DateTime?>
    {
        public int Compare(DateTime? x, DateTime? y)
        {
            return x.GetValueOrDefault().CompareTo(y.GetValueOrDefault());
        }
    }
