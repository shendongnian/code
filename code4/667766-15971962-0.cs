       public override object Convert(
                object value, 
                Type targetType, 
                object parameter,   
                CultureInfo culture)
            {
                if (value == null)
                {
                    return Visibility.Visible;
                }
                if (value.Equals("HideMe")
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
            public override object ConvertBack(
                object value, 
                Type targetType, 
                object parameter, 
                CultureInfo culture)
        {
            // TODO! Convert back to view model value
        }
