    foreach (var item in res)
    {
        Console.WriteLine("Format: " + item.Format);
        foreach (var item2 in item.Movies)
        {
            Console.WriteLine("\tMovie: " + item2.MovieName);
        }
    }
