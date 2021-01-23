    public static string TimeZoneToOffset(string tz)
		{
			tz = tz.ToUpper().Trim();
			for (int i = 0 ; i < TimeZones.Length ; i++)
			{
				if (((string)((string[])TimeZones.GetValue(i)).GetValue(0)) == tz)
				{
					return ((string)((string[])TimeZones.GetValue(i)).GetValue(1));
				}
			}
			return System.TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()
			.Replace(":", "").Substring(0, 5);
		}
