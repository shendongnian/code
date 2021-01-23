    var statistics = 
         blogList.GroupBy(val => new {val.BlogDate.Month, val.BlogDate.Year})
                 .OrderBy(item => item.Key.Year)
                 .ThenBy(item => item.Key.Month)
    	         .Select (grouped => new {Month = grouped.Key.Month, Year = grouped.Key.Year, Count = grouped.Count() });
	foreach (var item in statistics)
	{
		var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Month);
		Console.WriteLine (string.Format("{0} {1} ({2})", monthName, item.Year, item.Count));	
	}
