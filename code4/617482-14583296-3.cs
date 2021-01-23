    var dateString = "1st February 2013";
    DateTime date;
    var replaced = dateString.Substring(0,4)
                             .Replace("nd","")
                             .Replace("th","")
                             .Replace("rd","")
                             .Replace("st","")
                             + dateString.Substring(4);
    if (DateTime.TryParseExact(replaced, 
                                "dd MMMMM yyyy", 
                                CultureInfo.InstalledUICulture, 
                                DateTimeStyles.None, 
                                out date))
    {
     //valid date
    }
