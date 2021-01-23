    public class InvertBoolToVisibilityConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        var theBool = (bool)value;
        if (theBool)
          return Visibility.Collapsed;
        else
          return Visibility.Visible;
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
