    public class Article
    {
        public BsonObjectId Id { get; set; }
        public List<string> Content { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string DatePosted { get; set; }
        public string ArticleStatus { get; set; }
        public void AddContent(string c)
        {
            if (Content == null)
            {
                Content = new List<string>();
            }
            Content.Add(c);
        }
    }
   ...
            var article = new Article { Title = "Robs Article", Author = "Rob Paddock", DatePosted="1/1/1980", ArticleStatus="Live" };
            article.AddContent("Some html content here");
            article.AddContent("NYT Featured");
            article.AddContent("Recommended for gourmets");
            var articleCollection = database.GetCollection<Article>("articles");
            articleCollection.Insert(article);
