    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var config = value as ColumnConfig;
            if (config != null)
            {
                var grdiView = new GridView();
                for (int i = 0; i < config.Columns.Count; i++)
                {
                    var column = config.Columns[i];
                    var binding = new Binding("["+i +"]");
                    grdiView.Columns.Add(new GridViewColumn { Header = column.Header, DisplayMemberBinding = binding});
                }
                return grdiView;
            }
            return Binding.DoNothing;
        }
