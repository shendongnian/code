    Yes thats works for me . Thanx a lot. I have created the converter to set the visibility of the columns
    
       
    
    public class ColumnVisibilityConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                    {
                        List<string> list = value as List<string>;
                        string colName = parameter as string;
                        var visibility = list.Contains(colName) ? Visibility.Visible : Visibility.Collapsed;
                        return visibility;
                    }
                    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                    {
                        throw new NotImplementedException();
                    }
                }
    
    
    and in xaml i have binded like this
    
    <DataGridTextColumn Header="Name" MinWidth="200" Binding="{Binding Name}" CanUserResize="True"  Visibility="{Binding Data.Columns,Source={StaticResource proxy},Converter={StaticResource ColumnVisibilityConverter}, ConverterParameter='Name'}"/>
    <DataGridTextColumn Header="Status" Binding="{Binding Status}" MinWidth="140" CanUserResize="True" Visibility="{Binding Data.Columns,Source={StaticResource proxy},Converter={StaticResource ColumnVisibilityConverter}, ConverterParameter='Status'}" />
    <DataGridTextColumn Header="File Name" Binding="{Binding FileName}" MinWidth="150" CanUserResize="True" Visibility="{Binding Data.Columns,Source={StaticResource proxy},Converter={StaticResource ColumnVisibilityConverter}, ConverterParameter='File Name'}" />
    <DataGridTextColumn Header="Size" Binding="{Binding ImgSize}" MinWidth="100" CanUserResize="True" Visibility="{Binding Data.Columns,Source={StaticResource proxy},Converter={StaticResource ColumnVisibilityConverter}, ConverterParameter='Size'}" />
    <DataGridTextColumn Header="Height" Binding="{Binding Height}" MinWidth="100" CanUserResize="True" Visibility="{Binding Data.Columns,Source={StaticResource proxy},Converter={StaticResource ColumnVisibilityConverter}, ConverterParameter='Height'}" />
                        <DataGridTextColumn Header="Width" Binding="{Binding Width}" MinWidth="100" CanUserResize="True" Visibility="{Binding Data.Columns,Source={StaticResource proxy},Converter={StaticResource ColumnVisibilityConverter}, ConverterParameter='Width'}" />
    
    
    and in view model i have updated the columns according to the selecting list
    
    private void UpdateColumns(object c)
    {
               if (c == null)
                    return;
                
                var cols = ((IEnumerable)c).Cast<string>().ToList();
                
                Columns.Clear();
                Columns.AddRange(cols);
                RaisePropertyChanged(() => Columns);
    }
