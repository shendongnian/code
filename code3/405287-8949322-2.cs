    public class Range<TValue> 
        where TValue : IComparable<TValue>
    {
        public TValue Min { get; set; }
        public TValue Max { get; set; }
        public Range(TValue min, TValue max)
        {
            this.Min = min;
            this.Max = max;
        }
    }
    public class RangeComparer<TValue> : IRangeComparer<Range<TValue>, TValue> 
        where TValue : IComparable<TValue>
    {
        /// <summary>
        /// Returns 0 if value is in the specified range;
        /// less than 0 if value is above the range;
        /// greater than 0 if value is below the range.
        /// </summary>
        public int Compare(Range<TValue> range, TValue value)
        {
            // Check if value is below range (less than min).
            if (range.Min.CompareTo(value) > 0)
                return 1;
            // Check if value is above range (greater than max)
            if (range.Max.CompareTo(value) < 0)
                return -1;
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
            new Range<int>(40001, int.MaxValue),
        };
        var rangeComparer = new RangeComparer<int>();
        Console.WriteLine(BinarySearch(ranges, 7, rangeComparer));       // gives 0
        Console.WriteLine(BinarySearch(ranges, 10007, rangeComparer));   // gives 1
        Console.WriteLine(BinarySearch(ranges, 40007, rangeComparer));   // gives 2
        Console.WriteLine(BinarySearch(ranges, 1, rangeComparer));       // gives 0
        Console.WriteLine(BinarySearch(ranges, 10000, rangeComparer));   // gives 0
        Console.WriteLine(BinarySearch(ranges, 40000, rangeComparer));   // gives 1
        Console.WriteLine(BinarySearch(ranges, 40001, rangeComparer));   // gives 2
    }
