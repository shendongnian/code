    public static bool ExtractNumber(string name, out double number, out string rest)
    {
      Match m = sExtractNumber.Match(name);
      string numbertext = m.Groups[1].Value;
      rest = m.Groups[2].Value;
      return double.TryParse(numbertext, out number);
    }
