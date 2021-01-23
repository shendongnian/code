    public static DateTime ParseDate(string s)
    {
      var ts = TimeSpan.Parse(s);
      var now = DateTime.Now;
      return new DateTime(now.Year,
                          now.Month,
                          now.day,
                          ts.Hours % 24,
                          ts.Minutes,
                          ts.Seconds);
    }
