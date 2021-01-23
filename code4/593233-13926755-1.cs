    public static void DoSomething<T>(IIndexer<T, int> obj)
    {
        for (int i = 0; i < 5; i++)
        {
            T o = obj[i];
            // do what you need
        }
    }
