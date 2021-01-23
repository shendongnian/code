    var groupList = from a in (
    from m in db.Messages
    where m.UserId == userId || m.UserIdTo == userId
    join u in db.Users on m.UserId equals u.UserId
    join w in db.Users on m.UserIdTo equals w.UserId
    select new 
    {
     MessageId = m.MessageId,
     MessageContent = m.MessageContent,
     MessageTimestamp = m.MessageTimestamp,
     UserId = m.UserId,
     UserIdTo = m.UserIdTo,
     ScreenName = u.ScreenName,
     ScreenName2 = w.ScreenName
    })
    group a by new { 
    	UserId = a.UserId,
    	 UserIdTo = a.UserIdTo
    	} into grp
    orderby grp.Max(a => a.MessageTimestamp) descending
    select new
    {
     UserId = grp.Key.UserId
     UserIdTo = grp.Key.UserIdTo,
     MessageId = grp.Max(a => a.MessageId),
     MessageContent = grp.Max(a => a.MessageContent),
     MessageTimestamp = grp.Max(a => a.MessageTimestamp),
     ScreenName = grp.Max(a => a.ScreenName),
     ScreenName2 = grp.Max(a => a.ScreenName2)
    }
