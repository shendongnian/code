    public static class DateTimeExtensions
    {
      public static string GetValue(this DateTime value)
      {
        string returnValue = "--.--.--";
        if (value != new DateTime())
        {
          returnValue = value.ToString(CultureInfo.InvariantCulture);
        }
        return returnValue;
      }
    }
