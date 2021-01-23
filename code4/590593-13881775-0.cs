    private static ArticleNewsItemDetailsViewModel ConstructItem(ArticleNewsItem source)
        {
            var newsItem = new ArticleNewsItem
                               {
                                   Prop1 = source.Prop1,
                                   Prop2 = source.Prop2
                               };
            var result = new ArticleNewsItemDetailsViewModel()
                             {
                                 ArticleNewsItem = newsItem
                             };
            return result;
        }
