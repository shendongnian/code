    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public static bool IsContained(Range super, Range sub)
        {
            return super.Min <= sub.Min
                && super.Max >= sub.Max;
        }
    }
    public class Itemi
    {
        public Itemi()
        {
            properties = new Range[25];
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i] = new Range();
            }
        }
        private Range[] properties;
        public IEnumerable<Range> Properties { get { return properties; } }
        public static bool IsContained(Itemi super, Itemi sub)
        {
            return super.properties
                .Zip(sub.properties, (first, second) => Tuple.Create(first, second))
                .All((entry) => Range.IsContained(entry.Item1, entry.Item2));
        }
        public Range Prop1 
        { 
            get { return properties[0]; }
            set { properties[0] = value; }
        }
        public Range Prop2
        {
            get { return properties[1]; }
            set { properties[1] = value; }
        }
        // ...
    }
