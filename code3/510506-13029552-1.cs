    // get all English language articles 
                var news = from na in datacontext.NewsArticles
                           where na.Deleted == false
                           join nt in datacontext.NewsArticlesText on na.ArticleId equals nt.ArticleId
                           where nt.LanguageCode == "en-GB"
                           select new NewsArticleItem
                           {
                               ArticleId = na.ArticleId,
                               ImageUrl = na.ImageUrl,
                               Headline = nt.Headline,
                               Abstract = nt.Abstract,
                               BodyText = nt.BodyText,
                               LanguageCode = nt.LanguageCode,
                               DateCreated = na.DateCreated
                           };
                return news.ToList();
