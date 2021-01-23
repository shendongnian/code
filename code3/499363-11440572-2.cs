       public static IList<Status> GetAdminStatuses(NoaStatusID currentStatus = NoaStatusID.draft)
        {
            using (var context = MemberDataContext.Create())
            {
                List<Status> stat=context.tblAdminStatus
                       .Where(s => s.InactiveDate > DateTime.Now || s.InactiveDate == null)
                       .Select(s => new Status()
                         {
                           StatusID=NoaStatusID)Enum.Parse(typeof(NoaStatusID),s.StatusID),
                           StatusDescription=s.StatusDesc
                         })
                       .ToList();
                switch (currentStatus)
                {
                    case NoaStatusID.draft:
                        stat=stat.Where(s => (s.StatusID == NoaStatusID.draft || s.StatusID == NoaStatusID.pending)).ToList();                                                     
                        break;
                    case NoaStatusID.pending:
                        stat = stat.Where(s => (s.StatusID == NoaStatusID.accepted || s.StatusID ==NoaStatusID.declined || s.StatusID ==NoaStatusID.pending)).ToList();
                        break;                        
                    case NoaStatusID.declined:
                        stat = stat.Where(s => (s.StatusID == NoaStatusID.draft || s.StatusID == NoaStatusID.pending || s.StatusID == NoaStatusID.declined)).ToList();
                        break;
                    case NoaStatusID.accepted:
                        stat = stat.Where(s => (s.StatusID == NoaStatusID.mailed || s.StatusID == NoaStatusID.monitor || s.StatusID == NoaStatusID.close || s.StatusID == NoaStatusID.accepted)).ToList();
                        break;
                    case NoaStatusID.mailed:
                        stat = stat.Where(s => (s.StatusID == NoaStatusID.mailed || s.StatusID == NoaStatusID.monitor || s.StatusID == NoaStatusID.close || s.StatusID == NoaStatusID.appeal)).ToList();
                        break;
                    case NoaStatusID.monitor:
                    case NoaStatusID.appeal:
                    case NoaStatusID.close:
                        stat = stat.Where(s => (s.StatusID == NoaStatusID.close || s.StatusID == NoaStatusID.appeal)).ToList();   
                        break;                    
                }
                
                return stat;
            }
        }
