            void MinimalShell_Loaded(object sender, RoutedEventArgs e)
        {
            // Open the Default Screen
            // The navigation view model will only return those links that can be executed.  In order
            // to do that, it will call the CanExecute() method on the links - which is an
            // asynchronous operation. 
            // "prime" the view model by asking for the links.  If we don't do this, the first
            // command entered in the shell will not work (all commands after that will work).
            this.ServiceProxy.NavigationViewModel.NavigationItems.Count();
            // Getthe Tasks group as a INavigationItem
            INavigationItem objINavigationItem = 
                (this.ServiceProxy.NavigationViewModel.DefaultItem as INavigationItem);
            // Cast the INavigationItem to a INavigationGroup
            INavigationGroup objINavigationGroup = (INavigationGroup)objINavigationItem;
            if (objINavigationGroup.DefaultChild is INavigationScreen)
            {
                // Get the Default Screen
                INavigationScreen objINavigationScreen = (INavigationScreen)objINavigationGroup.DefaultChild;
                // Set DefaultScreenName
                DefaultScreenName = objINavigationScreen.DisplayName;
                // The screen may not be ready yet
                // Wait until the screen can be opened
                while (!objINavigationScreen.ExecutableObject.CanExecuteAsync)
                {
                    // Do nothing until the screen can be opened
                }
                // Open the Default Screen
                objINavigationScreen.ExecutableObject.ExecuteAsync();
            }
        }
