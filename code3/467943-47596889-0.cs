    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Threading;
    
    namespace SiderExampleVerticalV2
    {
        internal class FixCulture
        {
            internal static System.Globalization.NumberFormatInfo currcult
                    = Thread.CurrentThread.CurrentCulture.NumberFormat;
    
            internal static NumberFormatInfo nfi = new NumberFormatInfo()
            {
                /*because manual edit properties are not treated right*/
                NumberDecimalDigits = 1,
                NumberDecimalSeparator = currcult.NumberDecimalSeparator,
                NumberGroupSeparator = currcult.NumberGroupSeparator
            };
        }
    
        public class ToOneDecimalConverter : IValueConverter
        {
            public object Convert(object value,
                Type targetType, object parameter, CultureInfo culture)
            {
                double w = (double)value;
                double r = Math.Round(w, 1);
                string s = r.ToString("N", FixCulture.nfi);
                return (s as String);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string s = (string)value;
                double w;
                try
                {
                    w = System.Convert.ToDouble(s, FixCulture.currcult);
                }
                catch
                {
                    return null;
                }
                return w;
            }
        }
    }
