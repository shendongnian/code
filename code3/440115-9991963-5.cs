    public sealed class BoostResultStorage
    {
        public readonly double Value;
        public BoostResultStorage(double value)
        {
            this.Value = value;
        }
        public static readonly BoostResultStorage Zero = new BoostResultStorage(0);
    }
    public sealed class Val
    {
        // Immutable fields are inheriently threadsafe 
        public readonly double A;
        public readonly double B;
        public readonly double X;
        // volatile is an easy way to make a single field thread safe 
        private volatile BoostResultStorage boostResult = BoostResultStorage.Zero;
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
                return boostResult.Value;
            }
            set
            {
                boostResult = new BoostResultStorage(value);
            }
        }
    }
