    private async void help_Click_1(object sender, RoutedEventArgs e)
    {
        string file = "C:\\AnyFolderInTheHardDrive\\GamesOfThrones.mp4";
        try
        {
            Windows.Storage.StorageFile file =
                await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(file);
            await Windows.System.Launcher.LaunchFileAsync(file);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }
