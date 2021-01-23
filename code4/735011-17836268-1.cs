    private double time = 0.00;
        public double Time
        {
            get { return time; }
            set { if (SetProperty(ref time, value)) IsDirty = true; }
        }
