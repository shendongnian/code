    sealed class Age
    {
        public static readonly Young = new Size(3.0);
        public static readonly Mature = new Size(2.0);
        public static readonly Ancient = new Size(1.0);
    
        public double Weight
        {
            get;
            private set;
        }
    
        private Age(float weight)
        {
            Weight = weight;
        }
    }
    sealed class Size
    {
        public static readonly Small = new Size(3.0);
        public static readonly Medium = new Size(2.0);
        public static readonly Large = new Size(1.0);
    
        public double Weight
        {
            get;
            private set;
        }
    
        private Size(float weight)
        {
            Weight = weight;
        }
    }
