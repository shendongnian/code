    static void Main(string[] args)
    {
        List<SiteInfo> sites = new List<SiteInfo>()
        {
            new SiteInfo() { Title = "Site A", Type = "Whatever 2" },
            new SiteInfo() { Title = "Site B", Type = "Whatever 1" },
            new SiteInfo() { Title = "Site C", Type = "Whatever 1" },
            new SiteInfo() { Title = "Site D", Type = "Whatever 3" },
            new SiteInfo() { Title = "Site E", Type = "Whatever 3" }
        };
    
        var sitesGroupedByType =
            sites.GroupBy(s => s.Type).Select(g => new { Type = g.Key,
                                        Sites = g.Select(site => new
                                        {
                                              site.Title,
                                              site.URL
                                        })});
    
        foreach (var siteTypeGroup in sitesGroupedByType.OrderBy(g => g.Type))
        {
            foreach(var site in siteTypeGroup.Sites)
            {
                Console.WriteLine(string.Format("Type => {0}, Title => {1}",
                                  siteTypeGroup.Type, site.Title));
            }
        }
    
        Console.ReadKey();
    }
