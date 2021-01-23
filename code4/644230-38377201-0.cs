	public static string GetTimeZoneAbbreviation(DateTime time)
	{
		string timeZoneAbbr;
		if(time.IsDaylightSavingTime() == true)
		{
			timeZoneAbbr = TimeZoneInfo.Local.DaylightName;
		}
		else
		{
			timeZoneAbbr = TimeZoneInfo.Local.StandardName;
		}
		return timeZoneAbbr;
	}
