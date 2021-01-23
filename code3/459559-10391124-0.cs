    struct Megawatt
    {
        private double Value { get; private set; }
        public Megawatt(double value) : this()
        {
            this.Value = value;
        }
        public static Megawatt operator +(Megawatt x, Megawatt y)
        {
            return new Megawatt(x.Value + y.Value);
        }
        public static Megawatt operator -(Megawatt x, Megawatt y)
        {
            return new Megawatt(x.Value - y.Value);
        }
        // unary minus
        public static Megawatt operator -(Megawatt x)
        {
            return new Megawatt(-x.Value);
        }
        public static Megawatt operator *(Megawatt x, double y)
        {
            return new Megawatt(x.Value * y);
        }
        public static Megawatt operator *(double x, Megawatt y)
        {
            return new Megawatt(x * y.Value);
        }
    }
