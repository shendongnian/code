     [TestCase(10, Result = 5)]
     public int Check (int tries)
        {
        int fails = 0;
        for (int i = 0; i < tries; i++)
        {
            if (i % 2 == 1) fails++;
        }
        return fails;
     }
