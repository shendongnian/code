    <Grid>
        <ComboBox x:Name="myComboBox" />
        <TextBlock  Text="Your choice.." 
                    IsHitTestVisible="False"
                    Visibility="{Binding ElementName=myComboBox, Path=SelectedItem, Converter={StaticResource yourChoiceLabelVisibilityConverter}}" />
    </Grid>
    public class YourChoiceLabelVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }
