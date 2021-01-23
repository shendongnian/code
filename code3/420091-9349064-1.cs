    public class Article
    {
        public string Name { get; set; }
        
        public string ImagePath { get; set; }
    }
    
    
     Article article1 = new Article() { Name = "name1", ImagePath = "path of image 1" };
     Article article2 = new Article() { Name = "name2", ImagePath = "path of image 2" };
    
     var articles = new List<Article>();
     articles.Add(article1);
     articles.Add(article2);
    
     lstView.DataContext = articles;
