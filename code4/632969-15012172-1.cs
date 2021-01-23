    public DodgySolution
    {
        public static DodgySolution Zero = new DodgySolution(null);
        private DodgySolution tail;
        private DodgySolution(DodgySolution tail)
        {
            this.tail = tail;
        }
        // This bit is O(1)
        public DodgySolution Increment()
        {
            return new DodgySolution(this);
        }
        // This bit isn't...
        public BigInteger ToBigInteger()
        {
            return tail == null ? BigInteger.Zero
                                : BigInteger.One + tail.ToBigInteger();
        }
    }
