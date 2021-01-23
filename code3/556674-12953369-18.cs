        public object Convert(object[] values, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            ToggleValue val = new ToggleValue();
            val.View = values[1] as CodecWidgetViewModel;
            val.Value = System.Convert.ToInt32(values[0]);
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
        public CodecWidgetViewModel View { get; set; }
    }
