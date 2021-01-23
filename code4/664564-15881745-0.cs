    public int GetRandomValue() 
    {
        // Seed the RNG with an integer that changes every 5 seconds.
        Random rnd = new Random((int)(DateTime.Now.Ticks / ticksIn5Seconds));
        // Generate a 6 digit random number.
        return rnd.Next(100000, 999999); 
    }
