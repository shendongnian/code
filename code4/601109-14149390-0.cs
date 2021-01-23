    var infos = TimeZoneInfo.GetSystemTimeZones();
    foreach (var info in infos)
    {
        Console.WriteLine(info.Id);
    }
