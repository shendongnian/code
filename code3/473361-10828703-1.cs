               class AnimatedGIFControl : System.Windows.Controls.Image
    {
        private Bitmap _bitmap; // Local bitmap member to cache image resource
        private BitmapSource _bitmapSource;
        public delegate void FrameUpdatedEventHandler();
        /// <summary>
        /// Delete local bitmap resource
        /// Reference: http://msdn.microsoft.com/en-us/library/dd183539(VS.85).aspx
        /// </summary>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool DeleteObject(IntPtr hObject);
        /// <summary>
        /// Override the OnInitialized method
        /// </summary>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Loaded += new RoutedEventHandler(AnimatedGIFControl_Loaded);
            this.Unloaded += new RoutedEventHandler(AnimatedGIFControl_Unloaded);
        }
        /// <summary>
        /// Load the embedded image for the Image.Source
        /// </summary>
        void AnimatedGIFControl_Loaded(object sender, RoutedEventArgs e)
        {
           // Get GIF image from Resources
            if (Properties.Resources.ProgressIndicator != null)
            {
                _bitmap = Properties.Resources.ProgressIndicator;
                Width = _bitmap.Width;
                Height = _bitmap.Height;
                _bitmapSource = GetBitmapSource();
                Source = _bitmapSource;
            }
        }
        /// <summary>
        /// Close the FileStream to unlock the GIF file
        /// </summary>
        private void AnimatedGIFControl_Unloaded(object sender, RoutedEventArgs e)
        {
            StopAnimate();
        }
        /// <summary>
        /// Start animation
        /// </summary>
        public void StartAnimate()
        {
            ImageAnimator.Animate(_bitmap, OnFrameChanged);
        }
        /// <summary>
        /// Stop animation
        /// </summary>
        public void StopAnimate()
        {
            ImageAnimator.StopAnimate(_bitmap, OnFrameChanged);
        }
        /// <summary>
        /// Event handler for the frame changed
        /// </summary>
        private void OnFrameChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                   new FrameUpdatedEventHandler(FrameUpdatedCallback));
        }
        private void FrameUpdatedCallback()
        {
            ImageAnimator.UpdateFrames();
            if (_bitmapSource != null)
                _bitmapSource.Freeze();
            // Convert the bitmap to BitmapSource that can be display in WPF Visual Tree
            _bitmapSource = GetBitmapSource();
            Source = _bitmapSource;
            InvalidateVisual();
        }
        private BitmapSource GetBitmapSource()
        {
            IntPtr handle = IntPtr.Zero;
            try
            {
                handle = _bitmap.GetHbitmap();
                _bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                    handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                if (handle != IntPtr.Zero)
                    DeleteObject(handle);
            }
            return _bitmapSource;
        }
    }
