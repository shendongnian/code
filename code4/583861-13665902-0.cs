    var fb = new FacebookClient();
    dynamic result = fb.Get(new { ids = new[] { "...", "..." } });
    
    var pages = new List<FBPage>();
    foreach (var page in result.Values)
    {
        var fbPage = new FBPage {
            Id = page.id,
            Name = page.name
        };
    
        pages.Add(fbPage);
    }
