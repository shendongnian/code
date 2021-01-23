    public class ListToBooleanConverter : IValueConverter
    {
      public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        if ((value != null) & (parameter != null)) {
          try {
            Int16 itmNum = Convert.ToInt32(parameter);
            List<bool> lst = value;
            return lst[itmNum];
          } catch (Exception ex) {
            return null;
          }
        }
          return null;
      }
      public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException("This method or operation is not implemented.");
      }
    }
