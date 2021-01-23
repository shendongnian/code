    class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {  
            double actualWidth;
            if (Double.TryParse(value.ToString(), out actualWidth))
            {
                if (actualWidth> 0)
                {
                    return actualWidth;
                }
            }
            return null;
        }
    }
