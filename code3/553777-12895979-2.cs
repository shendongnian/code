    //make some test data
    var links = new []
    {
        new    
        {
            LinkId = 1,
            LinkTitle = "A link",
            DateAdded = new DateTime(2012, 5, 1),
        },
        new
        {
            LinkId = 2,
            LinkTitle = "Another link",
            DateAdded = new DateTime(2012, 5, 1),
        },
        new
        {
            LinkId = 3,
            LinkTitle = "A link bro!",
            DateAdded = new DateTime(2012, 6, 1),
        },
        new
        {
            LinkId = 4,
            LinkTitle = "A link dude",
            DateAdded = new DateTime(2012, 6, 1),
        },
        new
        {
            LinkId = 5,
            LinkTitle = "A link man!",
            DateAdded = new DateTime(2012, 7, 1),
        },
    };
    //make some test data
    var articles = new []
    {
        new
        {
            ArticleId = 1,
            ArticleTitle = "An article",
            DateAdded = new DateTime(2012, 6, 1),
        },
        new
        {
            ArticleId = 2,
            ArticleTitle = "An article",
            DateAdded = new DateTime(2012, 6, 1),
        },
        new
        {
            ArticleId = 3,
            ArticleTitle = "An article",
            DateAdded = new DateTime(2012, 7, 1),
        },
        new
        {
            ArticleId = 4,
            ArticleTitle = "An article",
            DateAdded = new DateTime(2012, 8, 1),
        },
    };
                   
    //shape the articles so we can append them to the links                   
    var articlesShaped = from a in articles
                         select new
                         {
                             IsLink = false,
                             IsArticle = true,
                             a.DateAdded,
                         };
    //shape the links so we can append them to the articles
    var linksShaped = from l in links
                      select new
                      {
                          IsLink = true,
                          IsArticle = false,
                          l.DateAdded,
                      };
    //append the links and articles together
    var articlesAndLinks = articlesShaped.Concat(linksShaped);
    
    var query = from a in articlesAndLinks
                //group by the month and year
                group a by new { a.DateAdded.Month, a.DateAdded.Year } into grouping
                select new
                {
                    grouping.Key.Year,
                    grouping.Key.Month,
                    //get the number of links
                    NoOfLinksAdded = grouping.Where(a1 => a1.IsLink).Count(),
                    //get the number of articles
                    NoOfArticleAdded = grouping.Where(a1 => a1.IsArticle).Count(),
                };
