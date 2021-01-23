        public int FramesCount
        {
            get { return _framesCount; }
            set
            {
                _framesCount = value;
                if (ImageFileMask != null) ReloadFrames();
            }
        }
        public static readonly DependencyProperty FramesCountProperty =
            DependencyProperty.Register(
                "FramesCount",
                typeof(int),
                typeof(MyControl),
                new PropertyMetadata(false, (d, e) =>
                {
                    (d as MyControl).FramesCount = (int)e.NewValue;
                })
            );
