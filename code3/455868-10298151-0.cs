        class TestList : List<int>
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public TestList(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
        public new void Add(int item)
        {
            if (item < MinValue || item > MaxValue)
                throw new ArgumentException("Value is outside the acceptable range");
            base.Add(item);
        }
    }
