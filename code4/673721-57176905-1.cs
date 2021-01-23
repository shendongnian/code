        [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
        public sealed class StringToColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var stringValue = (string)value;
                SolidColorBrush solidColor = (SolidColorBrush)new BrushConverter().ConvertFromString(stringValue);
                return solidColor;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
