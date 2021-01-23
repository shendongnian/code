    public static IQueryalbe<LastVisitedUser> GetLastUsers(this IQueryable<User> query)
    {
        return query.OrderByDescending(u => u.LastVisited)
                    .Select(u => new LastVisitedUser {
                        ID = u.ID,
                        Username = u.Username,
                        Email = u.EmailAddress
                     });
    }
