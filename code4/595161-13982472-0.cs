    using System;
    using System.Windows.Media;
    using System.Windows.Data;
    using System.Globalization;
    namespace MyNamespace
    {
        public class BoolToBrushConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                // return a Pink SolidColorBrush if true, a Maroon if false
                return (bool)value ? Brushes.Pink : Brushes.Maroon;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                 return (SolidColorBrush)value == Brushes.Pink;
            }
        }
    }
