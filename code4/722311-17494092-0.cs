    public class TextBoxValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || string.IsNullOrEmpty(parameter as string))
                throw new ArgumentException("Invalid arguments specified for the converter.");
    
            switch (parameter.ToString())
            {
                case "labelText":
                    return string.Format("There are {0} characters in the TextBox.", ((string)value).Count());
                case "backgroundColor":
                    return ((string)value).Count() > 20 ? Brushes.SkyBlue : Brushes.White;
                default:
                    throw new ArgumentException("Invalid paramater specified for the converter.");
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
