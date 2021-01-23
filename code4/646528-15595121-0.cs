    private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int dice = rand.Next(1, 5);
            switch (dice)
            {
                case 1:
                    Image1.Source = new BitmapImage(new Uri(@"ms-appx:///Assets/1.png"));
                    
                    break;
                case 2:
                    two.Source = new BitmapImage(new Uri(@"ms-appx:///Assets/2.png"));
                    break;
                case 3:
                    three.Source = new BitmapImage(new Uri(@"ms-appx:///Assets/3.png"));
                    break;
                case 4:
                    four.Source = new BitmapImage(new Uri(@"ms-appx:///Assets/4.png"));
                    break;
            }
        }for bitmap image refrence will be "using Windows.UI.Xaml.Media.Imaging;"
