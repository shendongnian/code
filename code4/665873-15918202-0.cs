    // Consider whether you actually want DateTime.UtcNow.Date
    DateTime now = DateTime.UtcNow;
    DateTime deadline;
    switch (configEntity.Captureusersandgroups)
    {
        case "DAILY": deadline = now.AddDays(-1);
        case "WEEKYLY": deadline = now.AddDays(-7);
        case "MONTHLY": deadline = now.AddMonths(-1);
        // I'm assuming there's *always* a schedule
        default: throw new InvalidOperationException("Invalid schedule");
    }
    if (configEntity.GroupsLastrun > deadline)
    {
        continue;
    }
