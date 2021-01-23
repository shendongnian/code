    public class MyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                                System.Globalization.CultureInfo culture)
        {
            if (value is DependencyObject) 
            {
                var textBlock = FindChild<TextBlock>((DependencyObject)value, null);
                return (textBlock == null)?string.Empty:textBlock.Text;
            }
            else
                return String.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                      System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
