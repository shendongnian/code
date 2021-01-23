    class Program
    {
        static void Main(string[] args)
        {
            // Example 1:
            // 1st range is defined as continous range from 5 to 11 and 2nd is periodical sequence from 2 to 18 with step 2 (thus, 8 steps).
            // Intersection will return a periodic sequence from 6 to 10 with step 2.example 1
            ContinuousRange ex1_r1 = new ContinuousRange(5, 11);
            PeriodicRange ex1_r2 = new PeriodicRange(2, 2, 8);
            IEnumerable<int> ex1_intersection = ex1_r1.Values.Intersect(ex1_r2.Values);
            IList<Range> ex1_intersection_results = Range.ConstructAppropriate(ex1_intersection);
        }
    }
    abstract class Range
    {
        public abstract IEnumerable<int> Values { get; }
        public static IList<Range> ConstructAppropriate(IEnumerable<int> values)
        {
            var results = new List<Range>();
            results.Add(ContinuousRange.ConstructFrom(values));
            results.Add(PeriodicRange.ConstructFrom(values));
            if (!results.Any(r => r != null))
                results.Add(Points.ConstructFrom(values));
            return results.Where(r => r != null).ToList();
        }
    }
    class ContinuousRange : Range
    {
        int start, endInclusive;
        public ContinuousRange(int start, int endInclusive)
        {
            this.start = start;
            this.endInclusive = endInclusive;
        }
        public override IEnumerable<int> Values
        {
            get
            {
                return Enumerable.Range(start, endInclusive - start + 1);
            }
        }
        internal static ContinuousRange ConstructFrom(IEnumerable<int> values)
        {
            int[] sorted = values.ToArray();
            if (sorted.Length <= 1)
                return null;
            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] - sorted[i - 1] != 1)
                    return null;
            }
            return new ContinuousRange(sorted.First(), sorted.Last());
        }
    }
    class PeriodicRange : Range
    {
        int start, step, count;
        public PeriodicRange(int start, int step, int count)
        {
            this.start = start;
            this.step = step;
            this.count = count;
        }
        public override IEnumerable<int> Values
        {
            get
            {
                var nums = new List<int>();
                int i = start;
                int cur = 0;
                while (cur <= count)
                {
                    nums.Add(i);
                    i += step;
                    cur++;
                }
                return nums;
            }
        }
        internal static Range ConstructFrom(IEnumerable<int> values)
        {
            // check the difference is the same between all values
            if (values.Count() < 2)
                return null;
            var sorted = values.OrderBy(a => a).ToArray();
            int step = sorted[1] - sorted[0];
            for (int i = 2; i < sorted.Length; i++)
            {
                if (step != sorted[i] - sorted[i - 1])
                    return null;
            }
            return new PeriodicRange(sorted[0], step, sorted.Length - 1);
        }
    }
    class Points : Range
    {
        int[] nums;
        public Points(params int[] nums)
        {
            this.nums = nums;
        }
        public override IEnumerable<int> Values
        {
            get { return nums; }
        }
        internal static Range ConstructFrom(IEnumerable<int> values)
        {
            return new Points(values.ToArray());
        }
    }
