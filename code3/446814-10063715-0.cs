    static public string calculateAge(DateTime birthDate, DateTime now)
    {
      birthDate = birthDate.Date;
      now = now.Date;
      var days = now.Day - birthDate.Day;
      if (days < 0)
      {
        var newNow = now.AddMonths(-1);
        days += (int)(now - newNow).TotalDays;
        now = newNow;
      }
      var weeks = days / 7;
      days = days - weeks * 7;
      var months = now.Month - birthDate.Month;
      if (months < 0)
      {
        months += 12;
        now = now.AddYears(-1);
      }
      var years = now.Year - birthDate.Year;
      if (years > 0)
      {
        if (months > 0)
          return string.Format("{0} Years, {1} Months", years, months);
        else
          return string.Format("{0} Years", years);
      }
      if (months > 0)
      {
        var builder = new StringBuilder();
        builder.AppendFormat("{0} Months", months);
        if (weeks > 0)
          builder.AppendFormat(", {0} Weeks", weeks);
        if (days > 0)
          builder.AppendFormat(", {0} Days", days);
        return builder.ToString();
      }
      if (weeks > 0)
      {
        if (days > 0)
          return string.Format("{0} Weeks, {1} Days", weeks, days);
        return string.Format("{0} Weeks", weeks);
      }
      return string.Format("{0} Days", days);
    }
