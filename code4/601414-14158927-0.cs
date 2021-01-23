        public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool && (bool)value)
                return new SolidColorBrush(Colors.Red);
            else
                return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    <Window.Resources>
        <conv:BoolToColorConverter x:Key="boolToColorConverter"/>
    </Window.Resources>
     <GridViewColumn Header="Product" Width="60" DisplayMemberBinding="{Binding ProductID}" BackGround="{Binding Equality, Converter={StaticResource boolToColorConverter}}" />
