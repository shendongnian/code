        class StatusToColor : IValueConverter
        {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    SolidColorBrush retColor = new SolidColorBrush();
                    retColor.Color = System.Windows.Media.Color.FromRgb(0, 0, 0);
                    if ((bool)value)
                    {
                         retColor.Color = System.Windows.Media.Color.FromRgb(255, 0, 0);
                    }
                    else
                    {
                         retColor.Color = System.Windows.Media.Color.FromRgb(0, 128, 0);
                    }
                    return retColor;
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
    }
