    public static string GetStat(this List<Stat> stats, string key)
    {
      var val = stats.FirstOrDefault(item => item.Type == key);
      if (val != null)
        return val.Value ?? String.Empty;
      return String.Empty;
    } 
