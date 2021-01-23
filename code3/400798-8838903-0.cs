    IQueryable<string> blacklistedMailAddresses =
        Database.Set<Blacklist>().Select(b => b.Email);
    
    var result = Database.Set<User>()
        .Where(x => x.UsersProccessed.Any())
        .Where(x => !blacklistedMailAddresses.Contains(x.Email))
        .ToList();
