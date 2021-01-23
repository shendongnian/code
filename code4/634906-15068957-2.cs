    class ConcatenateInternal
    {
        public StringBuilder StringBuilder { get; private set; }
        public bool Finished { get; set; }
        public ConcatenateInternal(int capacity)
        {
            StringBuilder = new StringBuilder(capacity);
        }
    }
