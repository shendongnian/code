    public static class Generator
    {
        static int current = 0;
        static Random rand = new Random();
        public static string NextId()
        {
            return string.Format("MA {0:0000000}/{1}/{2:00000}", 
              rand.Next() % 100000,
              DateTime.Now.ToString("dd/MM/yyyy"),
              current++ );
        }
    }
