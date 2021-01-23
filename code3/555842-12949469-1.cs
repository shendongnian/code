    public class HeightToMarginConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo ci)
        {
            double clmnHeight = System.Convert.ToDouble(values[0]);
            double chrtHeight = System.Convert.ToDouble(values[1]);
            if (chrtHeight - clmnHeight < 20)
            {
                return new Thickness(0, 5, 0, 0);
            }
            else
            {
                return new Thickness(0, -20, 0, 0);
            }
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo ci)
        {
            return null;
        }
    }
