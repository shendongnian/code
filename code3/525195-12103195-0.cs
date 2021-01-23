    internal interface ISCO
    {
        double HotScore { get; set; }
    }
    class SCO : ISCO
    {
        public double HotScore { get; set; }
        public static IEnumerable<T> Sort<T>(IEnumerable<T> items) where T : ISCO
        {
            var sorted = items.ToList();
            sorted.Sort();
            return sorted;
        }
    }
