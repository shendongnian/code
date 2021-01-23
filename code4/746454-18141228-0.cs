    public static bool TryParseAnyDate(string dateValue, out DateTime result)
    {
      result = DateTime.MinValue;
      foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
      {
        if (DateTime.TryParse(dateValue, cultureInfo, DateTimeStyles.None, out result))
        {
          return true;
        }
      }
      return false;
    }
