    public class Base64BitmapImage : BitmapSource
    {
        private BitmapImage bitmap;
        private string base64Source;
        public string Base64Source
        {
            get { return base64Source; }
            set
            {
                base64Source = value;
                bitmap = new BitmapImage();
                if (DecodeFailed != null)
                {
                    bitmap.DecodeFailed += DecodeFailed;
                }
                using (var stream = new MemoryStream(Convert.FromBase64String(base64Source)))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                if (DecodeFailed != null)
                {
                    bitmap.DecodeFailed -= DecodeFailed;
                }
                bitmap.Freeze();
            }
        }
        public override event EventHandler<ExceptionEventArgs> DecodeFailed;
        public override bool IsDownloading
        {
            get { return false; }
        }
        public override PixelFormat Format
        {
            get { return bitmap != null ? bitmap.Format : base.Format; }
        }
        public override double DpiX
        {
            get { return bitmap != null ? bitmap.DpiX : base.DpiX; }
        }
        public override double DpiY
        {
            get { return bitmap != null ? bitmap.DpiY : base.DpiY; }
        }
        public override double Width
        {
            get { return bitmap != null ? bitmap.Width : base.Width; }
        }
        public override double Height
        {
            get { return bitmap != null ? bitmap.Height : base.Height; }
        }
        public override int PixelWidth
        {
            get { return bitmap != null ? bitmap.PixelWidth : base.PixelWidth; }
        }
        public override int PixelHeight
        {
            get { return bitmap != null ? bitmap.PixelHeight : base.PixelHeight; }
        }
        public override ImageMetadata Metadata
        {
            get { return bitmap != null ? bitmap.Metadata : base.Metadata; }
        }
        public override void CopyPixels(Array pixels, int stride, int offset)
        {
            if (bitmap != null)
            {
                bitmap.CopyPixels(pixels, stride, offset);
            }
        }
        public override void CopyPixels(Int32Rect sourceRect, Array pixels, int stride, int offset)
        {
            if (bitmap != null)
            {
                bitmap.CopyPixels(sourceRect, pixels, stride, offset);
            }
        }
        public override void CopyPixels(Int32Rect sourceRect, IntPtr buffer, int bufferSize, int stride)
        {
            if (bitmap != null)
            {
                bitmap.CopyPixels(sourceRect, buffer, bufferSize, stride);
            }
        }
        protected override Freezable CreateInstanceCore()
        {
            var instance = new Base64BitmapImage();
            instance.bitmap = bitmap;
            instance.base64Source = base64Source;
            return instance;
        }
    }
