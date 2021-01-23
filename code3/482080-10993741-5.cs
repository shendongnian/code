    // Important: Note that Instrument is now a CLASS!! 
    public class Instrument
    {
        public Instrument(double nos, double last)
        {
            this.NoS = nos;
            this.Last = last;
        }
        // NOTE: Private setters. Class can't be changed
        // after initialization.
        public double NoS { get; private set; }
        public double Last { get; private set; }
    }
