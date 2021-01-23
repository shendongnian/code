    public sealed class NumbersRandomizer
    {
        readonly Random rng = new Random();
        public int RandomValue()
        {
            switch (rng.Next(5))
            {
                case 0: return Numbers.One;
                case 1: return Numbers.Five;
                case 2: return Numbers.Ten;
                case 3: return Numbers.Eleven;
                case 4: return Numbers.Fifteen;
            }
        }
    }
