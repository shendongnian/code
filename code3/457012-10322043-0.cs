    public ItemPositionValueConverter : IValueConverter
    {
        public DataGrid DataGrid { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            if (DataGrid == null)
            {
                return null;
            }
            ItemContainerGenerator generator = DataGrid.ItemContainerGenerator;
            return generator.IndexFromContainer(generator.ContainerFromItem(value));
        }
        //you probably don't need ConvertBack put it is provided for completeness
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? index = value as int?
   
            if (index == null)
            {
                return null
            }
            if (DataGrid == null)
            {
                return null;
            }
            ItemContainerGenerator generator = DataGrid.ItemContainerGenerator;
            return generator.ItemFromContainer(generator.ContainerFromIndex(index.Value));
        }
    }
