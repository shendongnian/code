    var results = query.GroupBy(r => new
    {
        SentDate = System.Data.Objects.EntityFunctions.TruncateTime(r.Launch.EmailDeliveredDate),
        EventSubTypeID = r.EmailEventSubtypeID
    })
    .Select(x => new
    {
        x.Key.SentDate,
        x.Key.EventSubTypeID,
        NumResults = x.Count()
    })
    .ToList();
