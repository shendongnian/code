    public sealed class Val
    {
        // Immutable fields are inheriently threadsafe 
        public readonly double A;
        public readonly double B;
        public readonly double X;
        // volatile is an easy way to make a single field thread safe
        // box and unbox to allow double as volatile
        private volatile object boostResult = 0.0;
        public Val(double A, double B, double X)
        {
            this.A = A;
            this.B = B;
            this.X = X;
        }
        public double BoostResult
        {
            get
            {
                return (double)boostResult;
            }
            set
            {
                boostResult = value;
            }
        }
    }
