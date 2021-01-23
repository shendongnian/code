    [Flags]
    public enum HourRepType
    {
      None = 0,
      Twelve = 1,
      TwentyFour = 2,
      Both = Twelve | TwentyFour
    }
    public static HourRepType FormatStringHourType(string format, CultureInfo culture = null)
    {
      if(string.IsNullOrEmpty(format))
        format = "G";//null or empty is treated as general, long time.
      if(culture == null)
        culture = CultureInfo.CurrentCulture;//allow null as a shortcut for this
      if(format.Length == 1)
        switch(format)
        {
          case "O": case "o": case "R": case "r": case "s": case "u":
            return HourRepType.TwentyFour;//always the case for these formats.
          case "m": case "M": case "y": case "Y":
            return HourRepType.None;//always the case for these formats.
          case "d":
              return CustomFormatStringHourType(culture.DateTimeFormat.ShortDatePattern);
          case "D":
            return CustomFormatStringHourType(culture.DateTimeFormat.LongDatePattern);
          case "f":
            return CustomFormatStringHourType(culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern);
          case "F":
            return CustomFormatStringHourType(culture.DateTimeFormat.FullDateTimePattern);
          case "g":
            return CustomFormatStringHourType(culture.DateTimeFormat.ShortDatePattern + " " + culture.DateTimeFormat.ShortTimePattern);
          case "G":
            return CustomFormatStringHourType(culture.DateTimeFormat.ShortDatePattern + " " + culture.DateTimeFormat.LongTimePattern);
          case "t":
            return CustomFormatStringHourType(culture.DateTimeFormat.ShortTimePattern);
          case "T":
            return CustomFormatStringHourType(culture.DateTimeFormat.LongTimePattern);
          default:
            throw new FormatException();
        }
      return CustomFormatStringHourType(format);
    }
    private static HourRepType CustomFormatStringHourType(string format)
    {
      format = new Regex(@"('.*')|("".*"")|(\\.)").Replace(format, "");//remove literals
      if(format.Contains("H"))
        return format.Contains("h") ? HourRepType.Both : HourRepType.TwentyFour;
      return  format.Contains("h") ? HourRepType.Twelve : HourRepType.None;
    }
