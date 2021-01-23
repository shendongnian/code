    public class IntToVisibilityConverter : IValueConverter
        {
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
       int intValue (int)value;
        if(intValue == 1)
    return Visibility.Visible;
    else
    return Visibility.Collapsed;
    }
 
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
    throw new NotImplementedException();
    }
}
