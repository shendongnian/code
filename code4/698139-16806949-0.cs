    class ShortDateConverter : IValueConverter
    {
      public object Convert(object data, Type type, object parameter, CultureInfo culture)
      {
        string format = PrepareFormat(culture.DateTimeFormat.ShortDatePattern);
        
        DateTime date = (DateTime)data;
        
        return date.ToString(format, culture);
      }
      
      public object ConvertBack(object data, Type type, object parameter, CultureInfo culture)
      {
        return DateTime.ParseExact((string)data, PrepareFormat(culture.DateTimeFormat.ShortDatePattern), culture);
      }
      
      private string PrepareFormat(string format)
      {
        if (!format.Contains("dd"))
          format = format.Replace("d", "dd");
          
        if (!format.Contains("MM"))
          format = format.Replace("M", "MM");
          
        if (!format.Contains("yyyy"))
          format = format.Replace("yy", "yyyy");
          
        return format;
      }
    }
