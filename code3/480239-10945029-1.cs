	void Main()
	{
		var logs = new List<UserLog>
			{
				new UserLog() { Date = new DateTime(2012,1,1), UserName = "cburgdorf"},
				new UserLog{ Date = new DateTime(2012,1,1), UserName = "cburgdorf"},
				new UserLog{ Date = new DateTime(2012,1,1), UserName = "cburgdorf"},
				new UserLog{ Date = new DateTime(2012,1,1), UserName = "Mister Foo"},
				new UserLog{ Date = new DateTime(2012,1,1), UserName = "Mister Foo"},
				new UserLog{ Date = new DateTime(2012,1,2), UserName = "Mister Bar"},
				new UserLog{ Date = new DateTime(2012,1,2), UserName = "Mister Bar"},
				new UserLog{ Date = new DateTime(2012,1,2), UserName = "cburgdorf"},
				new UserLog{ Date = new DateTime(2012,1,2), UserName = "Mister Foo"},
				new UserLog{ Date = new DateTime(2012,1,2), UserName = "Mister Foo"},
				new UserLog{ Date = new DateTime(2012,1,2), UserName = "Mister Foo"},
				new UserLog{ Date = new DateTime(2012,1,2), UserName = "Mister Bar"}
			};
		
		logs
			.OrderByDescending (l => l.Date)
			.GroupBy (log => log.Date)		
			.Select (log => log
							.GroupBy (l => l.UserName)
							.Select (l => new 
							{
								Count = l.Count (),
								Value = l.FirstOrDefault (),
							})
							.OrderBy (l => l.Count).Last ())
			.Select (log => new 
			{
				Date = log.Value.Date,
				Count = log.Count,
				UserName = log.Value.UserName
			})
			.Take(10)
		
        //In LINQPad use Dump() to see the results:
        /*
			logs
				.OrderByDescending (l => l.Date)
				.GroupBy (log => log.Date)		
				.Select (log => log
								.GroupBy (l => l.UserName)
								.Select (l => new 
								{
									Count = l.Count (),
									Value = l.FirstOrDefault (),
								})
								.OrderBy (l => l.Count).Last ())
				.Select (log => new 
				{
					Date = log.Value.Date,
					Count = log.Count,
					UserName = log.Value.UserName
				})
				.Take(10)
				.Dump()
        */		
	}
	class UserLog
	{
		public DateTime Date {get;set;}
		public string UserName {get;set;}
	}
