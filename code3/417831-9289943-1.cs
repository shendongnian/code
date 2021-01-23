     public class ImageConverter : IValueConverter
        {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    var path = value as string;
        
                    if (path == null)
                    {
                        return DependencyProperty.UnsetValue;
                    }
                    //create new stream and create bitmap frame
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    try
                    {
                        bitmapImage.StreamSource = new FileStream(path, FileMode.Open, FileAccess.Read);
                        //load the image now so we can immediately dispose of the stream
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        //clean up the stream to avoid file access exceptions when attempting to delete images
                        bitmapImage.StreamSource.Dispose();
                        return bitmapImage;
                    }
                    catch (Exception)
                    {        
                        //do smth
                    }
                    
                }
    }
