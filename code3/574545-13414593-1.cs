     void SetupDefautPage()
        {
            if ((DefaultPage !=false)&&(DefaultPage !=true)) 
            {
                (Application.Current as App).DefaultPage = false;
            }
            if (DefaultPage==false)
             {
                ((App)Application.Current).RootFrame.Navigate(new Uri("/TermUsePage.xaml", UriKind.Relative));
             }
            else if(DefaultPage==true)
             {
               ((App)Application.Current).RootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
             }
          
             
        }
