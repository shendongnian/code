    DateTime date = DateTime.MinValue;
    if (DateTime.TryParseExact(testDate, 
    	  provider.DateTimeFormat.ShortDatePattern, // Change this line
    	  provider,
    	  DateTimeStyles.None,
    	  out date))
    	Console.WriteLine("Date: {0}", date);
    else
    	Console.WriteLine("Can't parse date: {0} / {1}", testDate, date);
