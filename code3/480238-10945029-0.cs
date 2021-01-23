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
			.GroupBy (log => log.Date)
			.Select (log => log
							.GroupBy (l => l.UserName)
							.OrderBy (l => l.Count ())
							.Last ()
							.FirstOrDefault ());
		
        //In LINQPad use Dump() to see the results:
        /*
        logs
			.GroupBy (log => log.Date)
			.Select (log => log
							.GroupBy (l => l.UserName)
							.OrderBy (l => l.Count ())
							.Last ()
							.FirstOrDefault ())
							.Dump();
        */		
	}
	class UserLog
	{
		public DateTime Date {get;set;}
		public string UserName {get;set;}
	}
