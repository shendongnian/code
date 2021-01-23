    string s = "08-02-2012";
    string format ="dd-MM-yyyy";
    //Get DateTime
    DateTime dateTime = DateTime.ParseExact(s, format,new System.Globalization.CultureInfo("en-US"));
    //Get string representation of DateTime
    string date = dateTime.ToString(format, new System.Globalization.CultureInfo("en-US"));
