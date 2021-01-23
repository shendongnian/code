    var timeSpans = dataSet.Tables[0].AsEnumerable()
        .Select(r => new {
            DurHour   = r.Field<String>("Duration").Split(':')[0],
            DurMinute = r.Field<String>("Duration").Split(':')[1]
        })
        .Select(x => new TimeSpan(int.Parse(x.DurHour), int.Parse(x.DurMinute), 0));
    Console.WriteLine("Total time in minutes: {0}", timeSpans.Sum(ts=>ts.TotalMinutes));
