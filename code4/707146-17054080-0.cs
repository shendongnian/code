    class Dice
    {
        private static Random diceRoll = new Random();
        private int _min;
        private int _max;
        public int Rolled { get; private set; }
        public Dice(int min, int max)
        {
            _min = min;
            _max = max;
            // initializes the dice
            Rolled = diceRoll.Next(_min, _max);
        }
        public int ReRoll
        {
            get
            {
                Rolled = diceRoll.Next(_min, _max);
                return Rolled;
            }
        }
    }
