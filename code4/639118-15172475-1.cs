    DateTime d1 = DateTime.Parse("03/01/2013");
    DateTime d2 = DateTime.Parse("04/01/2013");
    
    int days = (d2 - d1).TotalDays;
    
    for (i = 0; i <= days; i++) {
    	DateTime d = d1.AddDays(i);
    	if ((d.DayOfWeek == DayOfWeek.Monday)) {
    		Console.WriteLine(d);   //dateList.Add(d);   <------ this could be a List<DateTime> or List<string>
    	}
    }
    Output - M/dd/yyyy format
    -------
    3/04/2013
    3/11/2013
    3/18/2013
    3/25/2013
    4/01/2013
