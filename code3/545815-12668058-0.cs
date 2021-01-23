    public class EventIDConverter : IMultiValueConverter
    {
    #region IMultiValueConverter Members
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 2)
            return null;
        return string.Format("{0} {1}", values[0], values[1]);
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        if (value == null)
            return null;
        string[] splitValues = ((string)value).Split(' ');
        return splitValues;
    }
    #endregion
    }
