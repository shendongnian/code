    public static DateTime ParseDate(string s)
    {
      s = string.Join(":",s.Split(':').Select(x => (int.Parse(x) % 24).ToString()));
      return DateTime.Parse(s)
    }
