    var query = table.Rows.Cast<DataRow>()
        let eventTime = (DateTime)r[0]
        .GroupBy(r => new DateTime(eventTime.Year, eventTime.Month, eventTime.Day, eventTime.Hour, eventTime.Minute, eventTime.Second))
        .Select(g => new{
            g.Key, 
            Sum = g.Sum(r => (int)r[2]),
            Average = g.Average(r => (int)r[3])});
