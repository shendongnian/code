    public class PathToImageConverter : IValueConverter
    {
        private static IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string path = value as string;
            if (string.IsNullOrEmpty(path))
                return null;
            if ((path.Length > 9) && (path.ToLower().Substring(0, 9).Equals("isostore:")))
            {
                using (var sourceFile = isoStorage.OpenFile(path.Substring(9), FileMode.Open, FileAccess.Read))
                {
                    BitmapImage image = new BitmapImage();
                    image.SetSource(sourceFile);
                    return image;
                }
            }
            else
            {
                BitmapImage image = new BitmapImage(new Uri(path));
                return image;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
