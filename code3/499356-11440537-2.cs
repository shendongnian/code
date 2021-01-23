    public static IList<Status> GetAdminStatuses()
    {
      IQueryable<Status> stat=context.tblAdminStatus
           .Where(s => s.InactiveDate > DateTime.Now || s.InactiveDate == null)
           .Select(s => new Status()
           {
             StatusID=(MyStatusID)s.StatusID,
             StatusDescription=s.StatusDesc
           });
    }
