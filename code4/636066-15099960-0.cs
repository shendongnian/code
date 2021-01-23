        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (Requirelogin && !CurrentAppManager.IsUserLoggedIn)
            { 
               // Transfer URI to the login page and save it, after successful login, 
               // the login page navigate back to the stored URI
                ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("Login?" + Helpers.URI + "=" + e.Uri.ToString(), UriKind.Relative));
            }
            // if the user has just come from Login
            // remove it from the stack so they dont hit when pressing back
            var entry = NavigationService.BackStack.FirstOrDefault();
            if (entry != null && entry.Source.OriginalString.Contains("Login"))
            {
                NavigationService.RemoveBackEntry();
            }
        }
