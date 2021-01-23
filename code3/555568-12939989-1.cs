    public class PathImageConverter
        : MvxBaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format("squareresources/{0}.png", value.ToString().ToLower());
        }
    }
