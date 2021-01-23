    DateTime hwTime = DateTime.Now;
    try
    {
       TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
       Console.WriteLine("{0} {1} is {2} local time.", 
               hwTime, 
               hwZone.IsDaylightSavingTime(hwTime) ? hwZone.DaylightName : hwZone.StandardName, 
               TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local));
    }
    catch (TimeZoneNotFoundException)
    {
       Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.");
    }                           
    catch (InvalidTimeZoneException)
    {
       Console.WriteLine("Registry data on the Hawaiian STandard Time zone has been corrupted.");
    }
