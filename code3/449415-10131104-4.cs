    var categories = movies.SelectMany(m => m.Categories).Distinct();
    var groups = categories
        .Select(c => Tuple.Create(c, movies
                .Where(m => m.Categories.Contains(c))
                .OrderBy(m => m.Title)));
    foreach (var category in groups)
    {
        Console.WriteLine("Category: {0}", category.Item1);
        foreach (var movie in category.Item2)
        {
            Console.WriteLine(movie.Title);
        }
    }
