    public static IList<Status> GetAdminStatuses()
    {
      IQueryable<Status> stat=context.tblAdminStatus
           .Where(s => s.InactiveDate > DateTime.Now || s.InactiveDate == null)
           .Select(s => new Status()
           {
             // If database is storing '0' (as a varchar)
             StatusID=(MyStatusID)int.Parse(s.StatusID),
             StatusDescription=s.StatusDesc
           });
    }
