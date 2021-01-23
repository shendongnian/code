        protected void InitializeBitmapGeneration()
        {
                LayoutUpdated += (sender, e) => _UpdateImageSource();
        }
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
           "ImageSource",
           typeof(ImageSource),
           typeof(CountControl),
           new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the ImageSource property.  This dependency property 
        /// indicates ....
        /// </summary>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        private void _UpdateImageSource()
        {
            if (ActualWidth == 0 || ActualHeight == 0)
            {
                return;
            }
            ImageSource = GenerateBitmapSource(this, 16, 16);
        }
        public static BitmapSource GenerateBitmapSource(ImageSource img)
        {
            return GenerateBitmapSource(img, img.Width, img.Height);
        }
        public static BitmapSource GenerateBitmapSource(ImageSource img, double renderWidth, double renderHeight)
        {
            var dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.DrawImage(img, new Rect(0, 0, renderWidth, renderHeight));
            }
            var bmp = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(dv);
            return bmp;
        }
        public static BitmapSource GenerateBitmapSource(Visual visual, double renderWidth, double renderHeight)
        {
            var bmp = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            var dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush(visual), null, new Rect(0, 0, renderWidth, renderHeight));
            }
            bmp.Render(dv);
            return bmp;
        }
    }
