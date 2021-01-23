    public class QuantityToBoolConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                        System.Globalization.CultureInfo culture)
        {
            try
            {
                IEnumerable items = value as IEnumerable;
                if (items != null)
                {
                    return items.OfType<object>().Any();
                }
            }
            catch
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
