     public class SomeConverter: IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            string cellValue = value.ToString();
            return cellValue == "PASS";
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return false;
        }
    }
    <DataGrid ItemsSource="{Binding List}" AutoGenerateColumns="False">
    <DataGrid.Resources>
        <myApp:SomeConverter
            x:Key="SomeConverter">
        </myApp:SomeConverter>
        <Style TargetType="DataGridCell" x:Key="FlashStyle">
            <Style.Triggers>
                <DataTrigger 
                    Binding="{Binding Col1, 
                    Converter={StaticResource SomeConverter}}" 
                    Value="True" >
                    <DataTrigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard 
                                x:Name="Blink" 
                                AutoReverse="True" 
                                RepeatBehavior="Forever">
                                <ColorAnimationUsingKeyFrames 
                                    BeginTime="00:00:00"
                                    Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)">
                                    <EasingColorKeyFrame 
                                        KeyTime="00:00:01" 
                                        Value="Green" />
                                </ColorAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </DataGrid.Resources>
    <DataGrid.Columns>
        <DataGridTextColumn 
            Binding="{Binding Col1}" 
            CellStyle="{StaticResource FlashStyle}"></DataGridTextColumn>
        <DataGridTextColumn 
            Binding="{Binding Col2}"></DataGridTextColumn>
    </DataGrid.Columns>
