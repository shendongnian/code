    DateTime dt;
    bool success = DateTime.TryParseExact("20120321", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
    if (success)
    {
    	var result = dt.ToString("yyyy/MM/dd");
    }
