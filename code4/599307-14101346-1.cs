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
            if (MaxNumber < this.Count)
                base.Push(obj);
        }
    }
