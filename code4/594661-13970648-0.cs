        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                Uri uri = new Uri("http://www.foo.com/#/foo");
                await Launcher.LaunchUriAsync(uri);
            }
            catch (Exception exception)
            {
                //TODO
            }
        }
