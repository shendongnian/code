    public static class ImageHelper
    {
        private static ImageFormat[] supportedFormats = new ImageFormat[]
        {
            ImageFormat.Bmp,
            ImageFormat.Gif,
            ImageFormat.Jpeg,
            ImageFormat.Png,
            ImageFormat.Tiff,
            ImageFormat.Wmf,
            ImageFormat.Emf,
            ImageFormat.Exif
        };
        public static int GetImageOrder(this Image target)
        {
            for (int i = 0; i < supportedFormats.Length; i++)
            {
                if (target.RawFormat.Equals(supportedFormats[i]))
                {
                    return i;
                }
            }
            // the image format is not within our supported formats array:
            // just order it to the very end
            return 9999;
        }
    }
