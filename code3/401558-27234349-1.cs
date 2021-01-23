    var versionsGroupedByRoundedTimeAndAuthor = db.Versions.GroupBy(g => 
    new
    {
                    UserID = g.Author.ID,
                    Time = RoundUp(g.Timestamp, TimeSpan.FromMinutes(2))
    });
