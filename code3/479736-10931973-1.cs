    class Program
    {
        static void Main(string[] args)
        {
            Range[] l_ranges = new Range[] { 
                new Range() { Start = 10, End = 19 },
                new Range() { Start = 20, End = 29 },
                new Range() { Start = 40, End = 49 },
                new Range() { Start = 50, End = 59 }
            };
            var l_flattenedRanges =
                from l_range in l_ranges
                from l_point in Enumerable.Range(l_range.Start, 1 + l_range.End - l_range.Start)
                select l_point;
            var l_min = 0;
            var l_max = l_flattenedRanges.Max();
            var l_allPoints =
                Enumerable.Range(l_min, 1 + l_max - l_min);
            var l_missingPoints =
                l_allPoints.Except(l_flattenedRanges);
            var l_lastRange = new Range() { Start = l_missingPoints.Min(), End = l_missingPoints.Min() };
            var l_missingRanges = new List<Range>();
            l_missingPoints.ToList<int>().ForEach(delegate(int i)
            {
                if (i > l_lastRange.End + 1)
                {
                    l_missingRanges.Add(l_lastRange);
                    l_lastRange = new Range() { Start = i, End = i };
                }
                else
                {
                    l_lastRange.End = i;
                }
            });
            l_missingRanges.Add(l_lastRange);
            foreach (Range l_missingRange in l_missingRanges) {
                Console.WriteLine("Start = " + l_missingRange.Start + " End = " + l_missingRange.End);
            }
            Console.ReadKey(true);
        }
    }
    class Range
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
