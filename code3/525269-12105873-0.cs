    for (DateTime dates = startDate; dates <= endDate; dates.AddDays(1))
    {
        DateTime BeginingOfDay = new DateTime(dates.Year,dates.Month,dates.Day,0,0,0);
        DateTime EndOfDay =  BeginingOfDay.AddDays(1);
        int count = (from u in db.CDRs where (u.StartTime >= BeginingOfDay && u.StartTime < EndOfDay) select u).Count();;
        dictionary.Add(dates.ToString("MM/dd/yyyy"), count);
    }
