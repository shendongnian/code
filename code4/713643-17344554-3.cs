    public class myAnnotationsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (MainWindow.annotations != null)
            {
                try
                {
                    return MainWindow.annotations[value as string];
                }
                catch (KeyNotFoundException e)
                {
                    return "NULL";
                }
            }
            throw new NotFiniteNumberException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotFiniteNumberException();
        }
    }
