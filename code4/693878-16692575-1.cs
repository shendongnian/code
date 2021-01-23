    var merged = list.GroupBy(x => x.ArticleID)
                     .Select(g => new BillArticle { 
                                 ArticleID = g.Key,
                                 ArticleName = g.First().ArticleName,
                                 ArticleQuantity = g.Sum(x => x.ArticleQuantity),
                                 ArticlePrice = g.First().ArticlePrice
                             });
