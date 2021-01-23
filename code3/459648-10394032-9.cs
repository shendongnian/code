    public static Random _rand = new Random();
    public IEnumerable<T> Randomise<T>(IList<T> list)
    {
        while(true)
        {
            // we find count every time since list can change
            // between iterations
            yield return list[_rand.Next(list.Count)];
        }
    }
