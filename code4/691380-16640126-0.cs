    var ids = string.Join(",", ArticleQueriable(articles, 70001));
    
    
    Queriable<int> ArticleQueriable(Queriable<Article> tbl_Article, int parentID)
    {
        while (true)
        {
            var parent = tbl_Article.SingleOrDefault(a => a.ArticleID == parentID);
            
            if (parent != null)
            {
                parentID = parent.ArticlePart.Dump();
                yield return parentID;
            }
            else
            {
                yield break;
            }
        }
    }
