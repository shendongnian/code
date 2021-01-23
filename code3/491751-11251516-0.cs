    string eg = "9.1.2";
    DateTime dt;
    
    var fi = new System.Globalization.DateTimeFormatInfo();
    fi.ShortDatePattern = "y.M.d";
    fi.Calendar.TwoDigitYearMax = 99;
    bool b = DateTime.TryParse(eg, fi, System.Globalization.DateTimeStyles.None, out dt);
