    var clubs = db.Users
    .Where(u => u.UserName == User.Identity.Name)
    .SelectMany(u => u.ClubMembers)
    .Select(m => new SomeType{ Club = m.Club, NumberOfMembers = m.Club.ClubMembers.Count()})
    .ToList();
