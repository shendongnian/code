    public static string Print(this TimeSpan p) 
    {
      var sb = new StringBuilder();
      if(p.Days > 365)
        sb.AppendFormat("{0}yr, ", p.Years / 365);
      if(p.Days % 365 > 30) // hard-code 30 as month interval...
        sb.AppendFormat("{0}months, ", ( p.Days % 365 ) /30);
      if(p.Days % 365 % 30 > 7) 
        sb.AppendFormat("{0}weeks, ", p.Days % 365 % 30 / 7);
      if(p.Days % 365 % 30 % 7 > 0)
        sb.AppendFormat("{0}days, ", p.Days % 365 % 30 % 7);
      if(p.Hours > 0)
        sb.AppendFormat("{0}hr, ", p.Hours);
      // ... and so on ...
      sb.Remove(sb.Length - 2, 2); // remove the last ", " part.
      return sb.ToString();
    }
