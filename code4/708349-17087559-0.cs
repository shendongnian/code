    public class ViewModel
        {
            public ViewModel()
            {
                Columns = new List<string>
                {
                    "Width", "Height"
                };
            }
            public List<string> Columns { get; private set; }
        }
    
    public class CustomizedConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                List<string> list = value as List<string>;
                string keyword = parameter as string;
                return list.Contains(keyword);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
    <StackPanel>
            <TextBox Text="Width" IsEnabled="{Binding Columns, Converter={StaticResource CustomizedConverter}, ConverterParameter='Width'}" />
            <TextBox Text="Height" IsEnabled="{Binding Columns, Converter={StaticResource CustomizedConverter}, ConverterParameter='Height'}" />
            <TextBox Text="None" IsEnabled="{Binding Columns, Converter={StaticResource CustomizedConverter}, ConverterParameter='None'}" />
        </StackPanel>
