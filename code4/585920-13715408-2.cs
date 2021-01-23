    public class StringToXamlValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string xaml;
            if (value != null && !String.IsNullOrWhiteSpace(value.ToString))
            {
                xaml = value.ToString();
            }
            else
            {
                xaml = Settings.Default.DefaultLayoutView;
            }
    
            var root = XamlReader.Parse(xaml);
            return root;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
