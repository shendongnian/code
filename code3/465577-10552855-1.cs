    from site in Context.Sites
    where site.ID == 99
    select new {
        ID = site.ID,
        Name = site.Name,
        URL = site.URL,
        LastVisitedUser = site.Users.GetLastUsers().FirstOrDefault()
    }
