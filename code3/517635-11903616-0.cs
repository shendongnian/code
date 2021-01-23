    var siteConfigs = db.SiteConfigs.AsEnumerable().Select(a => new SiteConfigView()
                     {
                         Name = a.Name,
                         LinkColour = a.LinkColour,
                         SiteLogo = a.SiteLogo,
                         SiteBrands = a.SiteBrands.ToList()
                     }).ToList();
