    public class ToggleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            ToggleValue val = new ToggleValue();
            val.IsChecked = System.Convert.ToBoolean(values[0]);
            val.Value = System.Convert.ToInt32(values[1]);
            return val;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
            
        }
    }
    public class ToggleValue
    {
        public int Value { get; set; }
        public bool IsChecked { get; set; }
    }
