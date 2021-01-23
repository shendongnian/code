    public class IStorageItemInformationToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var fileInfo = value as FileInformation;
            if (fileInfo != null)
            {
                var bi = new BitmapImage();
                // The file is being opened asynchronously but we return the BitmapImage immediately.
                SetSourceAsync(bi, fileInfo);
                return bi;
            }
            return null;
        }
        private async void SetSourceAsync(BitmapImage bi, FileInformation fi)
        {
            try
            {
                using (var stream = await fi.OpenReadAsync())
                {
                    await bi.SetSourceAsync(stream);
                }
            }
            catch
            {
                // ignore failure
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
