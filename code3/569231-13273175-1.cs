    public NewsFilterModel GetNewsFilterModelByTagNames(string tagNames, int status)
    {
         var resultArticle = db.CtArticleDetail.Where(m => m.tagNames == tagNames);
         var resultPage  = db.PcPage.Where(m => m.tagNames == tagNames);
         
         var newsFilterModel = new NewFilterModel { ArticleDetails = resultArticle, Pages = resultPage };
         return newsFilterModel;
    }
