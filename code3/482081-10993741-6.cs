    // Instrument can be a struct again.
    public struct Instrument
    {
        private object nos;
        private object last;
        public double NoS
        {
            get { return (double)(this.nos ?? 0d); }
            set { this.nos = value; }
        }
        public double Last
        {
            get { return (double)(this.last ?? 0d); }
            set { this.last = value; }
        }
    }
