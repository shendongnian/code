    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace ConverterSpike
    {
        public class DateStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null) return string.Empty;
                var date = value as string;
                if (string.IsNullOrWhiteSpace(date)) return string.Empty;
    
                var formattedString = string.Empty; //Convert to DateTime, Check past or furture date, apply string format
                
                return formattedString;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
