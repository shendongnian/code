      public static class StringExtensions
      {
        public static DateTime TryParseDate(this string strToParse)
        {
          DateTime dt = new DateTime();
          DateTime.TryParse(strToParse, out dt);
          return dt;
        }
      }
