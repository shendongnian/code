    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace Project.Converters {
        public sealed class BooleanToVisibilityConverter : IValueConverter {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
                if (targetType != typeof(Visibility)) {
                    throw new InvalidOperationException("The target type must be of type Visibility");
                }
                bool visible = (bool)value;
                return visible ? Visibility.Visible : Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
                if (targetType != typeof(bool)) {
                    throw new InvalidOperationException("The target type must be of type Boolean");
                }
                return (Visibility)value == Visibility.Visible;
            }
        }
    }
