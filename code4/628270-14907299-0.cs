    protected override void OnNavigatedTo(NavigationEventArgs e)
            {
            base.OnNavigatedTo(e);
            //Rebind all bindings to update button background images
            if (e.NavigationMode == NavigationMode.Back)
            {
                this.DataContext = null;
                this.DataContext = settings;
            }
            ....
