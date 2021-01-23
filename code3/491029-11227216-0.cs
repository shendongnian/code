    public static bool IsNumeric(this string theValue)
    {
      long retNum;
      return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, 
                System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
    }
