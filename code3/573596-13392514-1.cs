    private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var imageSource = ((sender as Image).Source as BitmapImage).UriSource.OriginalString;
            if (imageSource.Contains("On"))
            {
                (sender as Image).Source = new BitmapImage(new Uri("Images/Off.png", UriKind.Relative));
            }
            else
            {
                (sender as Image).Source = new BitmapImage(new Uri("Images/On.png", UriKind.Relative));
            }
        }
