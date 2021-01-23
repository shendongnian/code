        // Launch a URI.
        private async void LaunchUriButton_Click(object sender, RoutedEventArgs e)
        {
            // Create the URI to launch from a string.
            var uri = new Uri(uriToLaunch);
            // Launch the URI.
            bool success = await Windows.System.Launcher.LaunchUriAsync(uri);
            if (success)
            {
                rootPage.NotifyUser("URI launched: " + uri.AbsoluteUri, NotifyType.StatusMessage);
            }
            else
            {
                rootPage.NotifyUser("URI launch failed.", NotifyType.ErrorMessage);
            }
        }
