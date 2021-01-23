    double dVal = Convert.ToDouble(args[0],
                                      System.Globalization.CultureInfo.InvariantCulture);
        
    var nfi = NumberFormatInfo.CurrentInfo.Clone() as NumberFormatInfo;
    nfi.NumberDecimalSeparator = ".";
        
    string result = string.Format(nfi, "{0}", dVal);
