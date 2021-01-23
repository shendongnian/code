    public class LanguageConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        if (parameter == null)
          return string.Empty;
        if (parameter is string)
          return Resources.ResourceManager.GetString((string)parameter);
        else
          return string.Empty;
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
