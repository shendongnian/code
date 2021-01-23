    var readings = new Dictionary<string, MeterReadingsChartData>();
    while (reader.Read())
    {
         string name = reader.GetString(0);
         DateTime date = reader.GetDateTime(1);
         double value = reader.GetDouble(2);
         MeterReadingsChartData group;
         if (!readings.TryGetValue(name, out group))
         {
             group = new MeterReadingsChartData {
                 Name = name, 
                 Values = new List<double>(),
                 Dates = new List<DateTime>()
             };
             readings[name] = group;    
         }
         group.Values.Add(value);
         group.Dates.Add(date);
    }
