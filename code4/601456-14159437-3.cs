    public class MyBooleanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? ">>" : "<<";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    <Button Click="OnClick" Content="{Binding IsGridVisible, Converter={StaticResource MyBooleanToStringConverter}}"/>
