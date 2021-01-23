    // here are some posts
    List<Post> posts = new List<Post>
    {
        new Post {DateAdded = new DateTime(2013, 1, 1, 0, 0, 0, DateTimeKind.Utc)},
        new Post {DateAdded = new DateTime(2013, 2, 1, 0, 0, 0, DateTimeKind.Utc)},
        new Post {DateAdded = new DateTime(2013, 2, 2, 0, 0, 0, DateTimeKind.Utc)},
        new Post {DateAdded = new DateTime(2013, 3, 1, 0, 0, 0, DateTimeKind.Utc)},
        new Post {DateAdded = new DateTime(2013, 3, 2, 0, 0, 0, DateTimeKind.Utc)},
        new Post {DateAdded = new DateTime(2013, 3, 3, 0, 0, 0, DateTimeKind.Utc)},
    };
            
    // And the parameters you requested
    TimeZoneInfo userTimeZone = TimeZoneInfo
                                    .FindSystemTimeZoneById("Central Standard Time");
    int year = 2013;
    int month = 2;
    
    // Let's get the start and end values in UTC.
    DateTime startDate = new DateTime(year, month, 1);
    DateTime startDateUtc = TimeZoneInfo.ConvertTimeToUtc(startDate, userTimeZone);
    DateTime endDate = startDate.AddMonths(1);
    DateTime endDateUtc = TimeZoneInfo.ConvertTimeToUtc(endDate, userTimeZone);
    
    // Filter the posts to those values.  Uses an inclusive start and exclusive end.
    var filteredPosts = posts.Where(x => x.DateAdded >= startDateUtc &&
                                         x.DateAdded < endDateUtc);
