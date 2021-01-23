    var fromDate = new DateTime(2012, 1, 1);
    var toDate = new DateTime(2012, 7, 1);
    var query = 
        from p in dc.Postings
        join e in dc.Employees on p.EmployeeId equals e.EmployeeId
        join j in dc.Jobs on p.JobCode equals j.JobCode
        join ce in dc.CentralTimeEmployees on e.EmployeeId equals ce.CtEmployeeId
        where (e.CostCentreId == 1 || e.CostCentreId == 3) // the SQL tested 1 or 3
           && (p.TransactionDate >= fromDate && p.TransactionDate <= toDate)
           && j.JobCode != "CTCIT00001"
           && ce.DatabaseCode == "CTL"
           && (ce.CostCentreId == 1 || ce.CostCentreId == 3)
        group new { ce.Hours, ce.LatestTimesheetEntry }
           by new { j.JobName, j.JobCode, e.ShortName } into g
        orderby g.Key.ShortName, g.Key.JobName
        select new
        {
            Name = g.Key.ShortName.Trim(),
            JobName = g.Key.JobName.Trim(),
            JobCode = g.Key.JobCode,
            Hours = g.Sum(x => x.Hours),
            LastTimeSubmitted = g.Max(x => x.LatestTimesheetEntry),
        };
