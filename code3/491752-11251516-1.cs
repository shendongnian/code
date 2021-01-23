    string eg = "9.1.2";
    DateTime dt;
    
    var fi = new System.Globalization.DateTimeFormatInfo();
    fi.Calendar = (System.Globalization.Calendar)fi.Calendar.Clone();
    fi.Calendar.TwoDigitYearMax = 99;
    fi.ShortDatePattern = "y.M.d";
    bool b = DateTime.TryParse(eg, fi, System.Globalization.DateTimeStyles.None, out dt);
