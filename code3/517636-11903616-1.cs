    var siteConfigs = db.SiteConfigs.AsEnumerable().Select(a => new SiteConfigView()
                     {
                         Name = a.Name,
                         LinkColour = a.LinkColour,
                         SiteLogo = a.SiteLogo,
                         SiteBrands = a.SiteBrands.AsEnumerable().Select(a => new SiteBrandView()
                         {
                              //Do the projection
                         }).ToList()
                     }).ToList();
