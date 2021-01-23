    var daysOfWeek = new Quartz.Collection.HashSet<System.DayOfWeek>() { System.DayOfWeek.Wednesday, System.DayOfWeek.Thursday, System.DayOfWeek.Friday };
    DateTimeOffset startTime = DateBuilder.DateOf(0, 0, 0, 14, 1, 2013);
    DateTimeOffset endTime = DateBuilder.DateOf(0, 0, 0, 20, 1, 2013);
    TimeOfDay startTimeOfDay = TimeOfDay.HourMinuteAndSecondOfDay(7, 30, 0);
    TimeOfDay endTimeOfDay = TimeOfDay.HourMinuteAndSecondOfDay(23, 45, 0);
    var tokyoTimeZoneId = "Tokyo Standard Time";
    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(tokyoTimeZoneId);
    var dailyTrigger = new DailyTimeIntervalTriggerImpl
    {
	StartTimeUtc = startTime.ToUniversalTime(),
	EndTimeUtc = endTime.ToUniversalTime(),
	StartTimeOfDay = startTimeOfDay,
	EndTimeOfDay = endTimeOfDay,
	RepeatIntervalUnit = IntervalUnit.Hour,
	DaysOfWeek = daysOfWeek,
	RepeatInterval = 3,             // every 3 hours
	TimeZone = timeZoneInfo,
	Key = new TriggerKey(Guid.NewGuid().ToString(), "my-group"),
    };
    // Compute fire times just to show simulated fire times
    IList<DateTimeOffset> fireTimes = TriggerUtils.ComputeFireTimes(dailyTrigger, null, 1000);
    foreach (var dateTimeOffset in fireTimes)
    {
	Console.WriteLine("utc:{0} - tokyo:{1}", dateTimeOffset,
	  TimeZoneInfo.ConvertTimeFromUtc(dateTimeOffset.DateTime, timeZoneInfo));
    }
