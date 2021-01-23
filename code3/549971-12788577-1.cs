      private void ArrowDownImg_Loaded(object sender, RoutedEventArgs e)
            {
                Visibility darkBackgroundVisibility = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
                var ArrowDownImg = sender as Image;
    
                if (darkBackgroundVisibility != Visibility.Visible)
                {
                    ArrowDownImg.Source = new BitmapImage(new Uri("/Images/appbar.arrow.down.circle.dark.rest.png", UriKind.Relative));
                }
                else
                {
                    ArrowDownImg.Source = new BitmapImage(new Uri("/Images/appbar.arrow.down.circle.light.rest.png", UriKind.Relative));
                }
            }
