    <TextBlock Visibility="{Binding YourString, Converter={StaticResource LengthConverter}" />
    <UserControl.Resources>
        <converter:LengthConverter x:Key="LengthToVisibilityConverter" />
    </UserControl.Resources>
    public class LengthToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = (string)value;
            return text.Length > 0 ? Visibility.Visible : Visibilty.Collapsed;
        }
     
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
