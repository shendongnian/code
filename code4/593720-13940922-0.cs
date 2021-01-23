    class DisposableBitmapImageWrapper : IDisposable
    {
        public BitmapImage Bitmap { get; private set; }
        public DisposableBitmapImageWrapper(BitmapImage bitmap)
        {
            Bitmap = bitmap;
        }
        public void Dispose()
        {
            //Do something with the BitmapImage
        }
    }
