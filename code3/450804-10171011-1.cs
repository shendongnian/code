    var itemsDict = rssDataContext.rss_Application_Blog_Category_Relationships
        .Where(x => x.Application_Blog.rss_Application.ID == 1)
        .Where(x => x.Blog_Category_ID == 1)
        .Select(x => new { 
            x.rss_Application_Blog.BlogTitle,
            x.rss_Application_Blog.BlogUri,
            x.rss_Application_Blog.ID
        })
        .AsEnumerable() // Do the rest of the query in-process
        .Select((value, index) => new { value, index })
        .ToLookup(pair => pair.index % 4,
                  pair => new MenuItem {
                     Name = pair.value.Blog_Title,
                     Uri = pair.value.Blog_Uri,
                     ID = pair.value.ID
                  });
