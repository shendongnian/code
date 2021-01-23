            BitmapImage imageSource = new BitmapImage();
            private void getImage()
            {
                Uri uir= new Uri("PATH", UriKind.Absolute);
                imageSource.ImageOpened += new EventHandler<RoutedEventArgs>(imageopenened);
            }
            void imageopened(object sender, RoutedEventArgs e)
            {
                HEIGHT = ImageSource.PixelHeight;
                WIDTH = ImageSource.PixelWidth;
            ...
            }
