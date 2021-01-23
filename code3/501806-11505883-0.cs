    public class StringToVisibility : IValueConverter
        {
            public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string str = value.ToString();
                if (str.Equals("0"))
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new System.NotImplementedException();
            }
        }
