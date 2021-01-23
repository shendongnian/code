    class FixedSizeStack : Stack
    {
        public int MaxNumber { get; set; }
        public FixedSizeStack(int Limit)
            : base()
        {
            MaxNumber = Limit;
        }
        public override void Push(object obj)
        {
            if (MaxNumber < this.Count)
                base.Push(obj);
        }
    }
