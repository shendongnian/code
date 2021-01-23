    public static DateTime RoundMinutes(this DateTime value)
	{
		return RoundMinutes(value, 30);
	}
	public static DateTime RoundMinutes(this DateTime value, int roundMinutes)
	{
		DateTime result = new DateTime(value.Ticks);
		int minutes = value.Minute;
		int hour = value.Hour;
		int minuteMod = minutes % roundMinutes;
		if (minuteMod <= (roundMinutes / 2))
		{
			result = result.AddMinutes(-minuteMod);
		}
		else
		{
			result = result.AddMinutes(roundMinutes - minuteMod);
		}
		return result;
	}
