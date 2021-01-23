    public static IList<Status> GetAdminStatuses()
    {
      IQueryable<Status> stat=context.tblAdminStatus
           .Where(s => s.InactiveDate > DateTime.Now || s.InactiveDate == null)
           .Select(s => new Status()
           {
             // If database is storing 'draft' (as a varchar)
             StatusID=Enum.Parse(typeof(MyStatusID), s.StatusID),
             StatusDescription=s.StatusDesc
           });
    }
