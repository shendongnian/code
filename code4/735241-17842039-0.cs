    public class ImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var imagePath = (string) value;
    
                switch (imagePath)
                {
                    case "warning":
                        return "/Images/warning.png";
                    case "error":
                        return "/Images/error.png";
                    default:
                        throw new InvalidOperationException();
                }
            }       
        }
