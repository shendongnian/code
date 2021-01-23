    var logMonthGroups = File.ReadLines("D:\\login.lgl")
        .Select(l => new { Cols = l.Split('|') })
        .Select(x => new
        {
            Ipaddress = x.Cols.ElementAtOrDefault(0),
            Sysname = x.Cols.ElementAtOrDefault(1),
            username = x.Cols.ElementAtOrDefault(2),
            text = x.Cols.ElementAtOrDefault(3),
            datetime = x.Cols.ElementAtOrDefault(4) == null ? DateTime.MinValue : DateTime.Parse(x.Cols[4])
        })
        .GroupBy(x => new { Year = x.datetime.Year, Month = x.datetime.Month })
        .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month);
    foreach(var group in logMonthGroups)
    {
        // add to the DataGridView ...
    }
