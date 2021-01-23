    var query = DBContext.Table1.Where(c => c.FacilityID == facilityID && c.FilePath != null && c.TimeStationOffHook < oldDate)
                                .OrderBy(c => c.FilePath)
                                .Skip(1000)
                                .Take(1000)
                                .Select(c => new { c.FilePath, c.FileName })
                                .ToList();
    foreach(var t in query)
    {
        Console.WriteLine(t.FilePath +"\\"+t.FileName);
    }
