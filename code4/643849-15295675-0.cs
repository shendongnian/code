    public class ImageToValidatedImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if()
                {
                    //return image1 
                }
                else
                {
                    //return image2
                }
                
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new Exception("Cant convert back");
            }
        }
