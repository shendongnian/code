    private static readonly Random random = new Random();
    private static readonly object randLock = new object();
    public virtual string GenerateNonce()
    {
        lock (randLock)
        {
            // Just a simple implementation of a random number between 123400 and 9999999
            return random.Next(123400, 9999999).ToString();
        }
    }
    // since you had protected access on random, I'm assuming sub classes want to use it
    // so you'll need to provide them with access to it
    protected int NextRandom(...)
    {
        lock (randLock)
        {
             random.Next(...);
        }
    }
