    public static DateTime ParseDate(string s)
    {
      var tokens = s.Split(':').Select(x => int.Parse(x));
      var now = DateTime.Now;
      return new DateTime(now.Year,
                          now.Month,
                          now.day,
                          tokens[0] % 24,
                          tokens[1],
                          tokens[2]);
    }
