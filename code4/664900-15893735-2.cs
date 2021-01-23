    var dateTime1 = System.DateTime.Parse("1980/10/11 12:00:00");
    var dateTime2 = System.DateTime.Parse("2010/APRIL/02 17:10:00");
    var dateTime3 = System.DateTime.Parse("10/02/10 03:30:34");
    var dateTime4 = System.DateTime.Parse("02/20/10");
    
    if (dateTime1.TimeOfDay.TotalSeconds == 0) {
    	Console.WriteLine("1980/10/11 12:00:00 - does not have Time");
    } else {
    	Console.WriteLine("1980/10/11 12:00:00 - has Time");
    }
    
    if (dateTime2.TimeOfDay.TotalSeconds == 0) {
    	Console.WriteLine("2010/APRIL/02 17:10:00 - does not have Time");
    } else {
    	Console.WriteLine("2010/APRIL/02 17:10:00 - Has Time");
    }
    
    if (dateTime3.TimeOfDay.TotalSeconds == 0) {
    	Console.WriteLine("10/02/10 03:30:34 - does not have Time");
    } else {
    	Console.WriteLine("10/02/10 03:30:34 - Has Time");
    }
    
    if (dateTime4.TimeOfDay.TotalSeconds == 0) {
    	Console.WriteLine("02/20/10 - does not have Time");
    } else {
    	Console.WriteLine("02/20/10 - Has Time");
    }
