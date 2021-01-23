    public static class ImageExtensions()
    {
        public static byte[] ToJpegByteArray(this BitmapImage bitmapImage)
        {
            if (bitmapImage == null)
            {
                throw new ArgumentNullException("bitmapImage");
            }
    
            using (var stream = new MemoryStream())
            {
                var writeableBitmap = new WriteableBitmap(
    				bitmapImage.PixelWidth,
    				bitmapImage.PixelHeight);
    
                // Write an image into the stream
                Extensions.SaveJpeg(
    				writeableBitmap,
    				stream,
    				bitmapImage.PixelWidth,
    				bitmapImage.PixelHeight,
    				0,
    				100);
    
                return writeableBitmap.ToByteArray();
            }
        }
    
        private const int SizeOfArgb = 4;
        public static byte[] ToByteArray(
    		this WriteableBitmap writeableBitmap,
    		int offset = 0,
    		int count = 0)
        {
            if (writeableBitmap == null)
            {
                throw new ArgumentNullException("writeableBitmap");
            }
    
            if (count == 0)
            {
                count = writeableBitmap.Pixels.Length;
            }
    
            int len = count * SizeOfArgb;
            byte[] result = new byte[len]; // ARGB
            Buffer.BlockCopy(writeableBitmap.Pixels, offset, result, 0, len);
            return result;
        }
    }
