    public class AtypeToImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(ImageSource))
                throw new InvalidOperationException("The target must be an ImageSource");
            BitmapImage result = null;
            int type = value.ToString();
            switch (type)
            {
                case "Good Service":
                    result = new BitmapImage(new Uri("/Images/status_good.png", UriKind.Relative));
                    break;
                case "Minor Delays":
                    result = new BitmapImage(new Uri("/Images/status_minor.png", UriKind.Relative));
                    break;
                //other cases
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
