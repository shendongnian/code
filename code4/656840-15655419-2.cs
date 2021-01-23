    public class DirectionVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ArrowDirection target;
            ArrowDirection current;
            try
            {
                current = (ArrowDirection)value;
            }
            catch (Exception)
            {
                return null;
            }
            if (Enum.TryParse(parameter.ToString(), out target))
            {
                if (current == target)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
