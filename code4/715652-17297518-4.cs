	var now = DateTime.Now;
	DateTime nearestFridayBeforeToday;
	if(now.DayOfWeek != DayOfWeek.Friday)
    {
		nearestFridayBeforeToday = now.AddDays(DayOfWeek.Friday - now.DayOfWeek) //returns first friday after today
									  .AddDays(-7); //so we need to subtract one week
    }
	else
    {
		nearestFridayBeforeToday = now;
    }
	
	var sixFridaysBeforeNow = Enumerable.Range(0, 6)
	                                    .Select(n => nearestFridayBeforeToday.AddDays(-7 * n));
	//print results 
	var r = sixFridaysBeforeNow.Select(d => string.Format("{0} : {1}", d, d.DayOfWeek));
	Console.WriteLine (string.Join(Environment.NewLine, r));
