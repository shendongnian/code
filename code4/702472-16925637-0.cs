    public static DateTime? ConvertNullDate(this DateTime? date)
    {
       if (date != null && date.Value != DateTime.MinValue)
          return date;
       return default(DateTime?);
    }
