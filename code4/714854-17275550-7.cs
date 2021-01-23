    static class RankExt
    {
        public static int Value(this Rank rank)
        {
            if (rank >= Rank.Ten)
            {
                return 10;
            }
            else
            {
                return (int)rank;
            }
        }
    }
