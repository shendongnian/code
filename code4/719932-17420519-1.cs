    public class MyRandom: Random
    {
        public MyRandom() : this(Environment.TickCount)
        {
        }
        public MyRandom(int seed) : base(seed)
        {
            this.seed = seed;
        }
        public int Seed
        {
            get { return seed; }
        }
        private readonly int seed;
    }
