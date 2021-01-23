DataContext.DailyVisits
    .Upsert(new DailyVisit
    {
        // new entity path
        UserID = userID,
        Date = DateTime.UtcNow.Date,
        Visits = 1,
    })
    // duplicate checking fields
    .On(v => new { v.UserID, v.Date })
    .WhenMatched((old, @new) => new DailyVisit
    {
        // merge / upsert path
        Visits = old.Visits + 1,
    })
    .RunAsync();
The underlying generated sql does a proper upsert. This command runs right away and does not use change tracking, so that is one limitation.
