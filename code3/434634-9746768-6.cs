    var articles = results.GroupBy(g => g.obj2.ID)
                          .ToDictionary(k => k.Key, v => new { 
                              InspectorArticle = v.Select(s => s.obj2).First(), 
                              InspectorSamples = v.Select(s => s.obj3) });
    foreach(var article in articles.OrderBy(a => a.Key).Select(kv => kv.Value))
    {
        Console.WriteLine("Article ID: #{0}", article.InspectorArticle.ID);
        foreach(var sample in article.InspectorSamples)
        {
            Console.WriteLine("\tSample ID: #{0}", sample.ID);
        }
    }
