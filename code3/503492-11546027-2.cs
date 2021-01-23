        [ValueConversion(typeof(double), typeof(Thickness))]
        public class SizeToInverseMarginConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (targetType != typeof(Thickness))
                    throw new InvalidOperationException("The target must be of type 'Thickness'");
    
                double vNewVal = -5000 + (double)value;
                return new Thickness(0, vNewVal, 0, 0);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
