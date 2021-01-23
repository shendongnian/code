        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TweetTextBox.Text))
                MessageBox.Show("Please enter text to tweet.");
            ITwitterAuthorizer auth = SharedState.Authorizer;
            if (auth == null || !auth.IsAuthorized)
            {
                NavigationService.Navigate(new Uri("/OAuth.xaml", UriKind.Relative));
            }
            else
            {
                var twitterCtx = new TwitterContext(auth);
                var media = GetMedia();
                twitterCtx.TweetWithMedia(
                    TweetTextBox.Text, false, StatusExtensions.NoCoordinate, StatusExtensions.NoCoordinate, null, false,
                    media,
                    updateResp => Dispatcher.BeginInvoke(() =>
                    {
                        HandleResponse(updateResp);
                    }));
            }
        }
