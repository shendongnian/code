    class Article
    {
        public List<Tag> Tags { get; set; }
    }
    
    //get related to a
    Article a;
    List<Article> allArticles;
    
    //So, first filter to get all articles that have at least one tag in common then sort by the count of tags in common
    List<Article> related = allArticles.Where(x=> x.Tags.Any(t=> a.Tags.Contains(t))
                             .OrderByDescending(x => x.Tags.Intersect(a.Tags).Count())
                             .ToList();
