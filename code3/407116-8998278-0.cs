    public class IntConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            if (value is int?)
            {
                int? intValue = (int?)value;
                if (intValue.HasValue)
                {
                    return intValue.Value.ToString();
                }
            }
    
            return Binding.DoNothing;
        }
    
        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            if(value is string)
            {
                int number;
                if (Int32.TryParse((string)value, out number))
                {
                    return number;
                }
            }
    
            return null;
        }
    }
