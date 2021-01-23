    public class StatusTypeNameToBrushConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var statusTypeName = (string)value;
            switch (statusTypeName)
            {
                case "Incomplete":
                    return Brushes.Red;
                default:
                    return Brushes.Black;
            }
        }
     
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
