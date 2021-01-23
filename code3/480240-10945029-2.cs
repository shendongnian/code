	void Main()
	{
		var logs = new List<UserLog>
			{
				new UserLog { Id= 1, Date = new DateTime(2012,1,1), Username = "cburgdorf"},
				new UserLog { Id= 2, Date = new DateTime(2012,1,1), Username = "cburgdorf"},
				new UserLog { Id= 3, Date = new DateTime(2012,1,1), Username = "cburgdorf"},
				new UserLog { Id= 4, Date = new DateTime(2012,1,1), Username = "Mister Foo"},
				new UserLog { Id= 5, Date = new DateTime(2012,1,1), Username = "Mister Foo"},
				new UserLog { Id= 6, Date = new DateTime(2012,1,2), Username = "Mister Bar"},
				new UserLog { Id= 7, Date = new DateTime(2012,1,2), Username = "Mister Bar"},
				new UserLog { Id= 8, Date = new DateTime(2012,1,2), Username = "cburgdorf"},
				new UserLog { Id= 9, Date = new DateTime(2012,1,2), Username = "Mister Foo"},
				new UserLog { Id= 10, Date = new DateTime(2012,1,2), Username = "Mister Foo"},
				new UserLog { Id= 11, Date = new DateTime(2012,1,2), Username = "Mister Foo"},
				new UserLog { Id= 12, Date = new DateTime(2012,1,2), Username = "Mister Bar"}
			};
		
		logs
			.OrderByDescending (l => l.Date)
			.GroupBy (log => log.Date)		
			.Select (log => log
							.GroupBy (l => l.Username)
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
				Username = log.Value.Username
			})
			.Take(10)
			.Dump();
			
			//In LINQPad use Dump() to see the results:
			/*
				logs
					.OrderByDescending (l => l.Date)
					.GroupBy (log => log.Date)		
					.Select (log => log
									.GroupBy (l => l.Username)
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
						Username = log.Value.Username
					})
					.Take(10)
					.Dump();
			*/
		
		
	}
	class UserLog
	{
		public int Id {get;set;}
		public DateTime Date {get;set;}
		public string Username {get;set;}
	}
	The result is:
		02.01.2012 00:00:00 | 3 | Mister Foo 
		01.01.2012 00:00:00 | 3 | cburgdorf 
