    using System;
    using System.Windows.Data;
    namespace WPFTest
    {
        public class FontSizeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null)
                    return null;
                double windowFontSize = (double)value;
                var scale = System.Convert.ToDouble(parameter);
                return windowFontSize * scale;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
