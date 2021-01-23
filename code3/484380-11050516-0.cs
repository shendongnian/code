            private void getImage()
            {
                Uri uir= new Uri("PATH", UriKind.Absolute);
                BitmapImage imageSource = new BitmapImage();
                imageSource.ImageOpened += new EventHandler<RoutedEventArgs>(imageopenened);
            }
            void imageopened(object sender, RoutedEventArgs e)
            {
                HEIGHT = ((BitmapImage)BackgroundBrush.ImageSource).PixelHeight;
                WIDTH = ((BitmapImage)BackgroundBrush.ImageSource).PixelWidth;
            ...
            }
