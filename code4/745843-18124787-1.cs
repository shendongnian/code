	void Main()
	{
		DateTime dt = new DateTime(2010, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc);
		UTCToLocal(dt);
		
		dt = new DateTime(2010, 7, 1, 10, 0, 0, 0, DateTimeKind.Utc);
		UTCToLocal(dt);
	}
	
	void UTCToLocal(DateTime datetime) {
		if (datetime.Kind != DateTimeKind.Utc)
			throw new ApplicationException();
	
		Console.WriteLine("UTC: {0} MOW: {1} IsDST: {2}", datetime, datetime.ToLocalTime(),TimeZoneInfo.Local.IsDaylightSavingTime(datetime.ToLocalTime()));
	}
