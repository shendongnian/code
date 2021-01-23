    class Die
    {
        private static Random _random;
        public int CurrentRoll { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }
        public Die(int min, int max)
        {
            Min = min;
            Max = max;
            Roll();
        }
 
        public int Roll()
        {
            CurrentRoll = _random.Next(Min, Max+1); // note the upperbound is exlusive hence +1
            return CurrentRoll;
        }
    }
