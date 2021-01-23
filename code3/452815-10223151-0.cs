        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Controls.ItemCollection items = values[0] 
                                as System.Windows.Controls.ItemCollection;
            int index = (int)(values[1]) + 1;
            ...
        }
