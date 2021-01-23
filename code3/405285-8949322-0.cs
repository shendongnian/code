    public class Range<TValue> where TValue : IComparable<TValue>
    {
        public IComparable<TValue> Min { get; set; }
        public IComparable<TValue> Max { get; set; }
        public Range(IComparable<TValue> min, IComparable<TValue> max)
        {
            this.Min = min;
            this.Max = max;
        }
    }
    public class RangeComparer<TRange, TValue> : IRangeComparer<TRange, TValue> 
        where TRange : Range<TValue>
        where TValue : IComparable<TValue>
    {
        public int Compare(TRange range, TValue value)
        {
            int minCompare = range.Min.CompareTo(value);
            // Check if value is below range.
            if (minCompare > 0)
                return minCompare;
                        
            // Check if value is above range.
            int maxCompare = range.Max.CompareTo(value);
            if (maxCompare < 0)
                return maxCompare;
            // Value is within range.
            return 0;
        }
    }
    static void Main(string[] args)
    {
        var ranges = new Range<int>[]
        {
            new Range<int>(1, 10000),
            new Range<int>(10001, 40000),
            new Range<int>(40000, int.MaxValue),
        };
        var rangeComparer = new RangeComparer<Range<int>,int>();
        int x;
        x = BinarySearch(ranges, 7, rangeComparer);       // gives 0
        x = BinarySearch(ranges, 10007, rangeComparer);   // gives 1
        x = BinarySearch(ranges, 40007, rangeComparer);   // gives 2
        x = BinarySearch(ranges, 1, rangeComparer);       // gives 0
        x = BinarySearch(ranges, 10000, rangeComparer);   // gives 0
        x = BinarySearch(ranges, 40000, rangeComparer);   // gives 1
        x = BinarySearch(ranges, 40001, rangeComparer);   // gives 2
    }
