    var pages = context.Pages.Select(page => new { 
                                                   PageData = page, 
                                                   Favs = page.UserFavorites 
                                                 })
                             .OrderByDescending(page => (page.Fav.Sum(userClickCount))
                             .ThenBy(page => page.PageData.everyoneClickCount)
                             .ThenBy(page => page.PageData.Name)
                             .ToList();
