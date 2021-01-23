        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 0.0;
            foreach (object item in values)
            {
                result += System.Convert.ToDouble(item);
            }
            return result;
        }
        public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
