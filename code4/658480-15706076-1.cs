    var readings = new Dictionary<string, MeterReadingsChartData>();
    while (reader.Read())
    {
        string name = reader.GetString(5);
        DateTime date = reader.GetDateTime(1);
        double value = reader.GetDouble(2);
        string typeName = reader.GetString(3);
        string unit = reader.GetString(4);
        MeterReadingsChartData group;
        if (!readings.TryGetValue(name, out group))
        {
            group = new MeterReadingsChartData(name, new List<Tuple<DateTime, double>>(), typeName, unit);
            readings[name] = group;
            readings[typeName] = group;
            readings[unit] = group;
        }
        group.DateAndValue.Add(new Tuple<DateTime, double>(date, value));
    }
