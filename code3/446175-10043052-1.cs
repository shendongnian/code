	public static class DateTimeMyFormatExtensions
	{
	  public static string ToMyFormatString(this DateTime dt)
	  {
	    return dt.ToString("MM/dd/yyyy");
	  }
	}
	
	public static class StringMyDateTimeFormatExtension
	{
	  public static DateTime ParseMyFormatDateTime(this string s)
	  {
	    var culture = System.Globalization.CultureInfo.CurrentCulture;
	    return DateTime.ParseExact(s, "MM/dd/yyyy", culture);
	  }
	}
