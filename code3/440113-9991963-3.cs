    public sealed class BoostResult
    {
        public readonly double value;
        public BoostResult(double value)
        {
            this.value = value;
        }
    }
    public sealed class Val
    {
        // Immutable fields are inheriently threadsafe
        public readonly double A;
        public readonly double B;
        public readonly double X;
        // volatile is an easy way to make a single field thread safe
        private volatile BoostResult boostResult;
        
        public Val(double A, double B, double X)
        {
            this.A = A;
            this.B = B;
            this.X = X;
        }
        public BoostResult BoostResult
        {
            get
            {
                return boostResult;
            }
            set
            {
                boostResult = value;
            }
        }
    }
