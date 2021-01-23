	/// <summary>
	/// Converts a string to a dateTime with the given format and kind.
	/// </summary>
	/// <param name="dateTimeString">The date time string.</param>
	/// <param name="dateTimeFormat">The date time format.</param>
	/// <param name="dateTimeKind">Kind of the date time.</param>
	/// <returns></returns>
	public static DateTime ToDateTime(this string dateTimeString, string dateTimeFormat, DateTimeKind dateTimeKind)
	{
		if (string.IsNullOrEmpty(dateTimeString))
		{
			return DateTime.MinValue;
		}
		DateTime dateTime;
		try
		{
			dateTime = DateTime.SpecifyKind(DateTime.ParseExact(dateTimeString, dateTimeFormat, CultureInfo.InvariantCulture), dateTimeKind);
		}
		catch (FormatException)
		{
			dateTime = DateTime.MinValue;
		}
		return dateTime;
	}
