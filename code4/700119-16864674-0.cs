        protected override async void OnNavigatedTo(NavigationEventArgs e)
           {
                try
                {
                    await GetNameOfAllAnimalsAsync();
                }
                catch (ArgumentNullException)
                {
                } 
            base.OnNavigatedTo(e);
            
          }
