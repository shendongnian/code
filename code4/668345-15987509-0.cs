    private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string imageFile = @"images\somepdffile.pdf";
            // Get the image file from the package's image directory
            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
            if (file != null)
            {
                bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }
        }
