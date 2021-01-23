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
        if (y < 0 || y > 99) {
          throw new FormatExcetpion("A number was outside the 0..99 range.");
        }
        return y.ToString("d2");
      }).ToArray();
      return String.Concat(s);
    }
