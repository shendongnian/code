    DateTime startTime = new DateTime(2012,09,01);
    DateTime now = DateTime.Now;
    var diff = now.Subtract (startTime);
    int daysToEndPeriod = diff.Days % 14;
    if (daysToEndPeriod == 0)
    	Console.WriteLine("end of pay period");
    else
    	Console.WriteLine("end of pay period is: " + DateTime.Now.AddDays(14-daysToEndPeriod).Date);
