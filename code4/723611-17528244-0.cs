    var d1 = DateTime.Today.AddHours(9.5);
    var d2 = DateTime.Today.AddHours(14);
    
    var first = new DateTime(d1.Year, d1.Month, d1.Day, d1.Minute == 0 ? d1.Hour : d1.Hour + 1, 0, 0);
    var second = new DateTime(d2.Year, d2.Month, d2.Day, d2.Minute == 0 ? d2.Hour : d2.Hour + 1, 0, 0);
    
    TimeSpan ts = second - first;
    
    //returns DateTimes affected. I.e., Today at, [10:00, 11:00, 12:00, 13:00, 14:00]
    IEnumerable<DateTime> dates = Enumerable.Range(0, (int)ts.TotalHours + 1).Select(hour => first.AddHours(hour));
    			
    //Or, if you just want the HOURs
    //returns just ints: i.e., DateTimes 10,11,12,13,14
    IEnumerable<int> hours = Enumerable.Range(0, (int)ts.TotalHours + 1).Select(hour => first.AddHours(hour).Hour);
