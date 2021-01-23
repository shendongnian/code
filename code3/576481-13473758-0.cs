     [ValueConversion(typeof(DateTime), typeof(string))]
        public class StringTime : IValueConverter
        {
            #region IValueConverter Members
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null || value.ToString() == "")
                {
                    return "";
                }
                String str = ((DateTime)value).ToString("hh:mm tt");
                return str;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null || value.ToString() == "")
                {
                    return value;
                }
                DateTime dtr = DateTime.MinValue.Date;
                dtr = dtr.AddYears(1899);
                if (value == null)
                    return dtr;
                dtr = dtr.AddHours(double.Parse((value.ToString().Substring(0, 2))));
                dtr = dtr.AddMinutes(double.Parse((value.ToString().Substring(3, 2))));
    			if(value.ToString().Substring(7, 2) == "PM")
    				dtr = dtr.AddHours(12);
    				
                return dtr;
            }
            #endregion
        }
