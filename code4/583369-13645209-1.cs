    public static class DateTimeExtensions
    {
          public static string GetValue(this DateTime value, string format)
          {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException("format");
            }
            string returnValue = "--.--.--";
            if (value != new DateTime())
            {
              returnValue = String.Format(format, value);
            }
            return returnValue;
          }
    }
