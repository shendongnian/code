    var session = db.Sessions.OrderBy(x => x.StartTime).FirstOrDefault();
    if (session != null)
    {
        // Use the session
    }
    else
    {
        // There weren't any sessions
    }
