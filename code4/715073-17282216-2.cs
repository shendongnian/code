    if (ArticleContent.Length > 260)
    {
       if (ArticleContent.Remove(ArticleContent.LastIndexOf('.') != -1)
       {
           ArticleContent = String.Concat(ArticleContent.Remove(ArticleContent.LastIndexOf('.')), "...");
       }
       else
       {
           ArticleContent = String.Concat(ArticleContent.Substring(0, 257), "...")
       }
    }
