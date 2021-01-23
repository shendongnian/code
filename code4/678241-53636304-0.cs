        private void Button1_Click(object sender, RoutedEventArgs e)
        {
                BitmapImage bmp = new BitmapImage();
                Uri u = new Uri("ms-appx:/Images/timer.png", UriKind.RelativeOrAbsolute);
                bmp.UriSource = u;
                // NOTE: change starts here
                Image i = new Image();
                i.Source = bmp;
                button1.Content = i;
        }
