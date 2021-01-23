    var merged = list.GroupBy(x => new {x.ArticleID, x.ArticlePrice }) // changed here
                     .Select(g => new BillArticle { 
                         ArticleID = g.Key.ArticleID, // changed here
                         ArticleName = (string)g.First().ArticleName,
                         ArticleQuantity = g.Sum(x => x.ArticleQuantity),
                         ArticlePrice = g.Key.ArticlePrice // changed here
                     });
