    public static string ToLocalString(this DateTime? date)
    {
      if(date == null)
      {
         return String.Empty;
      }
      else
      {
       return date.ToLocalString().ToString();
      }
    }
