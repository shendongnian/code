    public class StaticTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (parameter != null)
        {
            return App.StaticTexts.Items.SingleOrDefault(t => t.Name.Equals(parameter)).Content;
        }
        return null;
    }
