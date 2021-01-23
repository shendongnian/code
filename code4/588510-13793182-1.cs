    public class MyImageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            System.Xml.XmlElement labelValue = values[1] as System.Xml.XmlElement;
            if (labelValue != null)
            {
                return ((string)values[0]) == labelValue.InnerText;
            }
            return false;
        }
        public object[] ConvertBack(object value, Type[] targetType,
           object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
