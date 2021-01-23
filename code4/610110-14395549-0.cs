    //Create localization object from http://stackoverflow.com/questions/3184121/get-month-name-from-month-number
    System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
    //Initialize dateTime
    DateTime.TryParse(KeyWord, out dateTime);
    //Write Month name in KeyWord
    KeyWord = string.Format("%{0}%", dtfi.GetMonthName(dateTime.Month));
