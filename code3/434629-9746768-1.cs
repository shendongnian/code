    foreach(var article in results.GroupBy(g => g.obj2.ID))
    {
        Console.WriteLine("Article ID: #{0}", article.Key);
        foreach(var sample in results
                              .Where(s => s.obj3.InspectorArticleID == article.Key)
                              .Select(s => s.obj3))
        {
            Console.WriteLine("\tSample ID: #{0}", sample.ID);
        }
    }
