    period = new DateTime(2013,1,1);
    endPeriod = new DateTime(2013,1,1).AddMonths(1).AddDays(-1);
    account.AccountNumber = 1455;
    
    var q = from logs in db.logs
    where logs.AccountNumber == account.AccountNumber
    && logs.StartDateTime > period && logs.StartDateTime < endPeriod
    let time = new TimeSpan(logs.ElapsedHours, logs.ElapsedMinutes, 0).TotalMinutes
    group logs by time into g
    select new {
    Time = g.Key
    }
    
    var averageTime = q.Average(i => i.Time);
