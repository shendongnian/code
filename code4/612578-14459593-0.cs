    string date = "2013-01-22";
    string hour = "13";
    string minute = "15";
    
    var result = LocalDateTimePattern.ExtendedIsoPattern.Parse(date + "T" + hour + ":" + minute + ":00");
    
    if (result.Success == true)
    {
    	DateTimeZone source_zone = DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Brussels");
    	DateTimeZone target_zone = DateTimeZoneProviders.Tzdb.GetZoneOrNull("Australia/Melbourne");
    
    	if (source_zone != null && target_zone != null)
    	{
    		ZonedDateTime source_zoned_dt = result.Value.InZoneStrictly(source_zone);
    
    		Console.WriteLine(source_zoned_dt.ToInstant());
    		Console.WriteLine(source_zoned_dt);
    		Console.WriteLine(source_zoned_dt.WithZone(target_zone));
    	}
    	else
    	{
    		Console.WriteLine("time zone not found");
    	}
    }
    else
    {
    	Console.WriteLine("parsing failed");
    }
