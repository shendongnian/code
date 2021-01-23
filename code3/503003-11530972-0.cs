    var list = (from se in db.ServiceEntry
        join u in db.User on se.TechnicianID equals u.ID
        join s in db.System1 on se.SystemID equals s.ID
        join r in db.RunLogEntry on se.RunLogEntryID equals r.ID into joinRunLogEntry
        from r2 in joinRunLogEntry.DefaultIfEmpty()
        where se.ClosedDate.HasValue == false
        where se.ClosedDate.HasValue == false
            && se.Reconciled == false
        orderby se.ID descending
        select new ServiceSearchEntry()
        {
            ID = se.ID,
            ServiceDateTime = se.ServiceDateTime,
            Technician = u.FullName,
            System = s.SystemFullName,
            ReasonForFailure = se.ReasonForFailure,
            RunDate = (r2 == null ? (DateTime?)null : r2.RunDate)
        })
        .Skip((page - 1) * PageSize);
