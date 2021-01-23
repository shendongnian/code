    DateTime dtResult;
    var dt = DateTime.MinValue;
    if (DateTime.TryParseExact("02/13/2013", "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dtResult))
    {
    	dt = dtResult;
    }
