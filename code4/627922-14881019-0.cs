    List<DateTime> dates = new List<DateTime>()
    {
    	DateTime.Now.AddDays(1),
    	DateTime.Now.AddDays(7),
    	DateTime.Now.AddDays(3),
    	DateTime.Now.AddDays(6),
    	DateTime.Now.AddDays(5),
    	DateTime.Now.AddDays(2),
    	DateTime.Now.AddDays(3),
    };
    
    dates = dates.OrderByDescending(x => x).ToList();
    var result = dates.Skip(1)
    	.Select((x, i) => new { Date = dates[i], PreviousDate = x });
