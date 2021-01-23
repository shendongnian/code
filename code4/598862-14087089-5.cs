    public static string ToMyString(this TimeSpan ts)
    {
      if (ts < TimeSpan.Zero)
        throw new ArgumentOutOfRangeException();
      
      var parts = new List<string>();
      AddPart(parts, ts.Days, "Day");
      AddPart(parts, ts.Hours, "Hour");
      AddPart(parts, ts.Minutes, "Minute");
      AddPart(parts, ts.Seconds, "Second");
      if (parts.Count == 0)
        return "0";
      return string.Join(" ", parts);
    }
    static void AddPart(List<string> parts, int number, string name)
    {
      if (number == 1)
        parts.Add("1 " + name);
      else if (number > 1)
        parts.Add(string.Format("{0} {1}s", number, name));        
    }
