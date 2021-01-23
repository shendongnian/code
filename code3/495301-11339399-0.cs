     private void ExecuteInRange(Dictionary<Range,Action<int>> ranges)
        {
            foreach (var range in ranges)
            {
                if (range.Key.Value < range.Key.Max && range.Key.Value > range.Key.Max)
                    range.Value(range.Key.Value);
            }
        }
    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Value { get; set; }
    }
