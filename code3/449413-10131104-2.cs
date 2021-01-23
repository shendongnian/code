    var categories = movies.SelectMany(m => m.Categories);
    var groups = categories
      .Select(c => Tuple.Create(c, movies
        .Where(m => m.Categories.Contains(c))
        .OrderBy(m => m.Title)))
      .GroupBy(g => g.Item1);
    
    
    foreach (var category in groups)
    {
      Console.WriteLine("Category: {0}", category.Key);
    
      foreach (var movie in category.SelectMany(c => c.Item2).Select(m => m.Title).Distinct())
      {
        Console.WriteLine(movie);
      }
    }
