        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.RegisterAttached(
            "Image",
            typeof(ImageSource),
            typeof(IconButton),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsRender));
        public static ImageSource GetImage(DependencyObject target)
        {
            return (ImageSource)target.GetValue(ImageProperty);
        }
        public static void SetImage(DependencyObject target, ImageSource value)
        {
            target.SetValue(ImageProperty, value);
        }
