    class FixedSizeStack : Stack
    {
        private int MaxNumber;
        public FixedSizeStack(int Limit)
            : base()
        {
            MaxNumber = Limit;
        }
        public override void Push(object obj)
        {
            if (this.Count < MaxNumber)
                base.Push(obj);
        }
    }
