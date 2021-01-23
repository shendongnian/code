    public class ComboBoxItemsSourceConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if(value != null && value is int)
                {
                    int max = (int)value;
                    if (max == -1) return null;
                    return Enumerable.Range(1, max + 1);
                }
                else
                    return null;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
