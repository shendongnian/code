    public class TextLineConverter : MarkupExtension, IValueConverter
    {
        static TextLineConverter converter;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] results = null;
            string newText = value as string;
            if (newText != null)
            {
                results = newText.Split('\r');
                if (results.Length > 0)
                    for (int i = 0; i < results.Length; i++)
                        if (results[i].Length > 0)
                            if (results[i][0] == '\n')
                                results[i] = results[i].Substring(1, results[i].Length - 1);
            }
            return results;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (converter == null) converter = new TextLineConverter();
            return converter;
        }
        public TextLineConverter()
        {
        }
    }
