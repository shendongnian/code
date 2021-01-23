    public static class NumericParsingExtender
    {
        public static Int32 ToInt32(this String input, Int32 defaultValue = 0)
        {
          if (String.IsNullOrEmpty(input)) return defaultValue;
          Int32 val;
          return Int32.TryParse(input, out val) ? val : defaultValue;
        }
    }
