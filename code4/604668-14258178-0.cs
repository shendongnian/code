     <TextBlock Text="{Binding Order_Date, Converter={StaticResource DateFormatter}}" />
    class DateFormatter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          // your code 
        }
    }
