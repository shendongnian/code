    namespace BoardsForWindows.Controls
    {
        public sealed partial class BBPostImage : UserControl
        {
            private BitmapImage bitmapImage;
    
            public string Source
            {
                get { return (string)GetValue(SourceProperty); }
                set { SetValue(SourceProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SourceProperty =
                DependencyProperty.Register("Source", typeof(string), typeof(BBPostImage), new PropertyMetadata(null, SourceChanged));
    
            public BBPostImage()
            {
                this.InitializeComponent();
            }
    
            public static void SourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                BBPostImage image = d as BBPostImage;
                if (image == null)
                {
                    return;
                }
    
                string url = (e.NewValue ?? string.Empty).ToString();
                Uri uri = null;
                if (String.IsNullOrEmpty(url) || !Uri.TryCreate(url, UriKind.Absolute, out uri))
                {
                    image.imageViewer.Width = 200;
                    image.imageViewer.Height = 40;
                    image.imageViewer.Source = null;
                    return;
                }
    
                image.bitmapImage = new BitmapImage();
                image.bitmapImage.ImageFailed += image.bitmapImage_ImageFailed;
                image.bitmapImage.ImageOpened += image.bitmapImage_ImageOpened;
                image.bitmapImage.UriSource = uri;
    
                image.imageViewer.Source = null;
                image.imageViewer.Source = image.bitmapImage;
            }
    
            void bitmapImage_ImageOpened(object sender, RoutedEventArgs e)
            {
                Width = bitmapImage.PixelWidth;
                Height = bitmapImage.PixelHeight;
            }
    
            void bitmapImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
            {
                // TODO
            }
        }
    }
