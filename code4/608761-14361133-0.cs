    string DATE_FORMAT= "yyyyMMddhhmmss";
          
    DateTime date;
    if(DateTime.TryParseExact(str, DATE_FORMAT, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out date))
    {
    //success
    //you can use date
    }else
    {
    //fail
    }
