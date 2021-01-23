    class Program
    {
        static void Main(string[] args)
        {
            Bitmap oldBitmap = (Bitmap)pictureBox1.Image;;
            var bitmapAsWriteableBitmap = new WriteableBitmap(BitmapToBitmapImage(oldBitmap));
            bitmapAsWriteableBitmap.RotateFree(23);
            var rotatedImageAsMemoryStream = WriteableBitmapToMemoryStream(bitmapAsWriteableBitmap);
            oldBitmap = new Bitmap(rotatedImageAsMemoryStream);
        }
        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            var memStream = BitmapToMemoryStream(bitmap);
            return MemoryStreamToBitmapImage(memStream);
        }
        public static MemoryStream BitmapToMemoryStream(Bitmap image)
        {
            var memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Bmp);
            return memoryStream;
        }
        public static BitmapImage MemoryStreamToBitmapImage(MemoryStream ms)
        {
            ms.Position = 0;
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        }
        private static MemoryStream WriteableBitmapToMemoryStream(WriteableBitmap writeableBitmap)
        {
            var ms = new MemoryStream();
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
            encoder.Save(ms);
            return ms;
        }
    }
