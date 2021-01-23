	var text = "June 15";
	DateTime datetime;
	if(DateTime.TryParseExact(text, "m", CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out datetime))
	{
		// was just month, day, replace year with specific value:
		datetime = new DateTime(1966, datetime.Month, datetime.Day);
	}
	else
	{
		// wasn't just month, day, try parsing a "whole" date/time:
		datetime = DateTime.Parse(text);
	}
