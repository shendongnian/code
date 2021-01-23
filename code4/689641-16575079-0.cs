    try {
        using (LiveLeaseEntities db = LiveLeaseHelper.GetDbLiveLeaseEntities()) {
            return db.t_Project
                .Where(p => p.IsActive)
                .Select(p => new KeyValuePair<Guid, string>(p.ProjectId, p.ProjectName))
                .ToList();
         }
    } catch {
       ...
    }
