    foreach (var group in query)
    {
        Console.WriteLine("Tweets for {0}", group.Key);
        foreach (var tweet in group)
        {
            Console.WriteLine("  {0}", tweet.Text); // Or whatever
        }
    }
