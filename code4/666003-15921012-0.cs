    string strTime = "10:30AM";
    DateTime dtTime;
    if(DateTime.TryParseExact(strTime, "hh:mmtt",  
       System.Globalization.CultureInfo.InvariantCulture, 
       System.Globalization.DateTimeStyles.None, out dtTime))
     {
        Console.WriteLine(dtTime);
     }
