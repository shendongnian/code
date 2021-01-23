    string strTime = "04/30/2013 23:00";
    DateTime dtTime;
    if(DateTime.TryParseExact(strTime, "MM/dd/yyyy HH:mm",  
       System.Globalization.CultureInfo.InvariantCulture, 
       System.Globalization.DateTimeStyles.None, out dtTime))
     {
        Console.WriteLine(dtTime);
     }
