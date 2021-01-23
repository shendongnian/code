    public class Article
    { 
    public int ArticleID { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Anotation { get; set; }
    }
    public class ArticleTag
    {
    public int ArticleTagID { get; set; } 
    public int ArticleID { get; set; } //This creates the link 1-M
    public string TagName { get; set; }
    }
