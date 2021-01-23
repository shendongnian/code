    public static string DotFormatToRowKey(this string dotFormatRowKey) {
      var splits = dotFormatRowKey.Split('.');
      if (splits.Length != 2) {
        throw new FormatException("The string should contain one period.");
      }
      var s = splits.Select(x => {
        int y;
        if (!Int32.TryParse(x, out y)){
          throw new FormatException("A part of the string was not numerical");
        }
        return y;
      }).Select(x => String.Format("{0:d2}", x)).ToArray();
      return String.Concat(s);
    }
