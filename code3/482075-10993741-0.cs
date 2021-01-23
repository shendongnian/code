    public struct Instrument
    {
        public Instrument(double nos, double last)
        {
            this.NoS = nos;
            this.Last = last;
        }
        public double NoS { get; private set; }
        public double Last { get; private set; }
    }
