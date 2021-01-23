    class CanvasWithBitmap : Canvas
    {
        public CanvasWithBitmap()
        {
            _image = new BitmapImage (new Uri(@"c:\xyz.jpg"));
        }
    
        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawImage(_image,
                new Rect(0, 0, _image.PixelWidth, _image.PixelHeight));
        }
    
        private BitmapImage _image;
    }
