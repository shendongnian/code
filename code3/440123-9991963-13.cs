    public sealed class Val
    {
        public readonly double A;
        public readonly double B;
        public readonly double X;
        private readonly object lockObject = new object();
        private double boostResult;
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
                lock (lockObject)
                {
                    return boostResult;
                }
            }
            set
            {
                lock (lockObject)
                {
                    boostResult = value;
                }
            }
        }
    }
