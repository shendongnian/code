    IQueryable<Meet> query = _meetReadService.GetRecords()
                                             .Include(x => x.MeetType)
                                             .Include(x => x.MeetTeamMembers)
                                             .Select(z => z.User.Name).FirstOrDefault())
                                             .Where(x => x.EndDateTime <= DateTime.Now);
    var queryResults = query.ToList();
    foreach (var meet in queryResults) 
    {
        meet.MeetTeamMembers = meet.MeetTeamMembers.Where(e => e.MeetType.IsManager;
    }
