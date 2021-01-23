    var articleDictionary = articles.ToDictionary(
           a => a.Name, // article name is key
           a => ArticleTags
                 .where(t => t.ArticleID == a.Id)
                 .select(t => Tags.Single(tag => tag.id == t.id).TagName // value is an IEnumerable<string> of tag names
    )
    foreach (var article in articleDictionary)
    {
        Console.WriteLine(article.Key);
        foreach (var tag in article.Value)
        { 
            Console.WriteLine("\t" + tag)
        }
    }
   
