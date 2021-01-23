    <ListView ItemsSource="{Binding Players}">
        <ListView.Resources>
            <rxDummy:MultiplyConverter x:Key="MultiplyConverter"/>
        </ListView.Resources>
        <ListView.View>
            <GridView>
                <GridViewColumn x:Name="Rank" Header="Rank" DisplayMemberBinding="{Binding Rank}"
                                Width="{Binding ActualWidth, Mode=OneWay, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListView}}, 
                                            Converter={StaticResource MultiplyConverter}, 
                                            ConverterParameter=0.33}"/>
                <GridViewColumn Header="Username" DisplayMemberBinding="{Binding Username}" 
                                Width="{Binding ElementName=Rank, Path=ActualWidth}"/>
                <GridViewColumn Header="Score" DisplayMemberBinding="{Binding Score}" 
                                Width="{Binding ElementName=Rank, Path=ActualWidth}"/>
            </GridView>
        </ListView.View>
    </ListView>
<!== ==>
    public class MultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var d = System.Convert.ToDouble(value);
            double p = System.Convert.ToDouble(parameter,CultureInfo.InvariantCulture);
            return d * p;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
