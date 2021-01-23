     void DefaultLanguage() 
        {
                if (languageChooser==null)
                {
                    ((App)Application.Current).RootFrame.Navigate(new Uri("/SplashPage.xaml", UriKind.Relative));
                }
                else if (languageChooser =="Norwegian")
                {
                    ((App)Application.Current).RootFrame.Navigate(new Uri("/MainPage.xaml?Language=Norwegian", UriKind.Relative));
                }
                else if (languageChooser =="English")
                {
                    ((App)Application.Current).RootFrame.Navigate(new Uri("/MainPage.xaml?Language=English", UriKind.Relative));
                }
              
            }
        }
