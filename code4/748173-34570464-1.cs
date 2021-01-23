        private void MyBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var image = sender as Image;
            var bitmapImage = image?.Source as BitmapImage;
            if (bitmapImage != null)
            {
                var source = bitmapImage.UriSource.LocalPath;
                if (source == "/Assets/Green1 (Custom).png")
                {
                    MyBox.Source = new BitmapImage() { UriSource = new Uri("ms-appx:///Assets/Red1 (Custom).png", UriKind.Absolute) };
                }
                else if (source == "/Assets/Red1 (Custom).png")
                {
                    MyBox.Source = new BitmapImage() { UriSource = new Uri("ms-appx:///Assets/Green1 (Custom).png", UriKind.Absolute) };
                }
            }
