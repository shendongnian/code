    namespace DataGridTest
    {
        using System;
        using System.Windows.Data;
    
        public sealed class SentinelConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null && string.Equals("{NewItemPlaceholder}", value.ToString(), StringComparison.Ordinal))
                {
                    return null;
                }
    
                return value;
            }
        }
    }
