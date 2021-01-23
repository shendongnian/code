    using System.Globalization;
    
    CultureInfo enUS = new CultureInfo("en-US");                
    DateTime dateValueOut;
    string userCreated = "Fri May 03 15:22:09 +0000 2013"; 
    
    bool isDateFormatted = DateTime.TryParseExact(userCreated,"ddd MMM dd HH:mm:ss zzzz yyyy",enUS,DateTimeStyles.None, out dateValueOut);
    
    if (isDateFormatted == true)
    {
        DateTime formattedDateTime = dateValueOut;                    
    }
