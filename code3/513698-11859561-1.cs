    public class StaticTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter is string)
            {
                return App.StaticTexts.Items.SingleOrDefault(t => t.Name.Equals(parameter)).Content;
            }
            return null;
        }
    }
