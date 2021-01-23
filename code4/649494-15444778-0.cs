    Int32 numberOfProjects = (from entry in DbSet
                  where entry.Timesheet.UserID == userid
                  select entry.ActivityCode.ActivityCode1).Distinct().Count();
    var summary = from entry in DbSet
                  where entry.Timesheet.UserID == userid &&
                  entry.Timesheet.DateSubmitted >= startdate &&
                  entry.Timesheet.DateSubmitted <= enddate
                  group entry by entry.ActivityCode.ActivityCode1
                      into groupEntry
                      select new TimeSheetSummary()
                      {
                          ActivityCode = groupEntry.Key,
                          HourSpent = Convert.ToInt32(groupEntry.Sum(x => x.Duration)),
                          Percentage = (Convert.ToInt32(groupEntry.Sum(x => x.Duration)) / numberOfProjects) * 100,
                          MinuteSpent = Convert.ToInt32(groupEntry.Sum(x => x.Duration)) * 60,
                      };
