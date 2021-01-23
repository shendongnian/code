    public class IndexTovisibilityConverter: IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
         int index= (int)value;
    
          if (index > 3)
            return Visibility.Collapsed;
          else
            return Visibility.Visible;
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        return null;
      }
    }
