         if (boolvariable)
            {
                RootFrame.Navigate(new Uri("YourPage.xaml", UriKind.Relative));
                boolvariable = false;
            }
         else 
            {
                RootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
