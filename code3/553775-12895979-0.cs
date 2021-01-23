    var query = from n in Enumerable.Range(0, 1) //we need something to start our query from
                //shape the articles so we can append them to the links 
                let articlesShaped = from a in articles
                                     select new
                                     {
                                         IsLink = false,
                                         IsArticle = true,
                                         a.DateAdded,
                                     }
                //shape the links so we can append them to the articles
                let linksShaped = from l in links
                                  select new
                                  {
                                      IsLink = true,
                                      IsArticle = false,
                                      l.DateAdded,
                                  }
                //append the links and articles together
                let articlesAndLinks = articlesShaped.Concat(linksShaped)
                from a in articlesAndLinks
                group a by new { a.DateAdded.Month, a.DateAdded.Year } into grouping
                select new
                {
                    grouping.Key.Year,
                    grouping.Key.Month,
                    NoOfLinksAdded = grouping.Where(a1 => a1.IsLink).Count(),
                    NoOfArticleAdded = grouping.Where(a1 => a1.IsArticle).Count(),
                };
