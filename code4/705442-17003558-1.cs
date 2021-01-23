    public static string FromNowFormatted(this DateTime date)
    {
        var sb = new StringBuilder();
        
        var t = DateTime.Now - date;
        
        var dic = new Dictionary<string, int>
                  {
                      {"years", (int)(t.Days / 365)},
                      {"months", (int)(t.Days / 12)},
                      {"days", t.Days},
                      {"hours", t.Hours},
                      {"minutes", t.Minutes},
                      {"seconds", t.Seconds},
                  };
        
        bool b = false;
        foreach (var e in dic)
        {                
            if (e.Value > 0 || b)
            {
                var v = e.Value;
                var k = v == 1 ? e.Key.TrimEnd('s') : e.Key ;
                
                sb.Append(v + " " + k + "\n");
                b = true;
            }
        }
        
        return sb.ToString();
    }
