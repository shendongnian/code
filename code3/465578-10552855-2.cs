    public static IQueryalbe<SiteModel> GetSiteModels(this IQueryable<Site> query)
    {
        return query.Select(site => new SiteModel {
                         ID = site.ID,
                         Name = site.Name,
                         URL = site.URL,
                         LastVisitedUser = site.Users
                                               .OrderByDescending(u => u.LastVisited)
                                               .Select(u => new LastVisitedUser {
                                                    ID = u.ID,
                                                    Username = u.Username,
                                                    Email = u.EmailAddress
                                                }});
    }
