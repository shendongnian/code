	/// <summary>
	/// Converts the value of the current System.DateTime object to its equivalent string representation using the specified format and culture-specific format information.
	/// </summary>
	/// <param name="date">DateTime instance</param>
	/// <param name="format">A standard or custom date and time format string.</param>
	/// <returns>A string representation of value of the current System.DateTime object as specified by format and provider.</returns>
	public static string ToFormatString(this DateTime date, string format) {
		return date.ToString(format, new CultureInfo("en-US"));
	}
	/// <summary>
	/// Returns the number of milliseconds since Jan 1, 1970 (useful for converting C# dates to JS dates)
	/// </summary>
	/// <param name="dt">Date Time</param>
	/// <returns>Returns the number of milliseconds since Jan 1, 1970 (useful for converting C# dates to JS dates)</returns>
	public static double UnixTicks(this DateTime dt) {
		DateTime d1 = new DateTime(1970, 1, 1);
		DateTime d2 = dt.ToUniversalTime();
		TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
		return ts.TotalMilliseconds;
	}
