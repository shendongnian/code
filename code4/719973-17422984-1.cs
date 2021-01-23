    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Limit { get; set; }
        public int Result{get;set;}
        public Range(int min, int max, int limit, int result)
        {
            this.Min = min;
            this.Max = max;
            this.Limit = limit;
            this.Result = result;
        }
        public bool InRange(int value)
        {
            if (value >= this.Min && value <= this.Max && value <= limit)
                return true;
            return false;
        }
    }
