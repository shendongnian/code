    DateTime dt;
    string[] formats = { "yyyyMMdd", "yyyy" };
    bool success = DateTime.TryParseExact("20120321", formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
    if (success)
    {
    	var result = dt.ToString("yyyy/MM/dd");
    	Console.WriteLine(result);
    }
