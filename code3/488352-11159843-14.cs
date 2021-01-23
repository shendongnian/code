    class Something
    {
        private int _w;
        public int Weight
        {
            get { return _w; }
            set
            {
                if (value < 100)
                    throw new ArgumentException("weight too small");
                _w = value;
                RecalculateDensity();
            }
        }
        // and other methods
    }
    something.Weight = otherSomething.Weight + 1; // much cleaner, right?
