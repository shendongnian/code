    public class AreaConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            
            //you can do this in one line, but I split it for clarity.
            var xml = value as IEnumerable<XmlNode>;
            var areas = xml.Select(x => x.Attributes["Area"].Value);
            var avg = areas.Average(a => int.Parse(a));
            return avg;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportException();
        }
    }
