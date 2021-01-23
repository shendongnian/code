    var itemsDict = rssDataContext.rss_Application_Blog_Category_Relationships
        .Where(x => x.Application_Blog.rss_Application.ID == 1)
        .Where(x => x.Blog_Category_ID == 1)
        .ToArray()
        .Select((x, index) => new
            {
                Index = index,
                Item = new MenuItem
                {
                    Name = x.rss_Application_Blog.Blog_Title,
                    Uri = x.rss_Application_Blog.Blog_Uri,
                    ID = x.rss_Application_Blog.ID
                }
            });
        .GroupBy(i => i.Index / 4)
        .ToDictionary(g => g.Key);
