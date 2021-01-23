    public sealed class ImageCache
    {
        private static readonly Dictionary<string, Bitmap> Images;
        static ImageCache()
        {
            Images = new Dictionary<string, Bitmap>();
            // load XML file here and add images to dictionary
            // You'll want to get the name of the file from an application setting.
        }
        public static bool TryGetImage(string key, out Bitmap bmp)
        {
            return Images.TryGetValue(key, out bmp);
        }
    }
