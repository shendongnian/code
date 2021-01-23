    string str = "1st February 2013";
    DateTime dtObject;
    string replacedStr =  str.Substring(0,4)
                             .Replace("nd","")
                             .Replace("th","")
                             .Replace("rd","")
                             .Replace("st","")
                             + str.Substring(4);
    if (DateTime.TryParseExact(replacedStr, 
                                "dd MMMMM yyyy", 
                                CultureInfo.InstalledUICulture, 
                                DateTimeStyles.None, 
                                out dtObject))
    {
     //valid date
    }
