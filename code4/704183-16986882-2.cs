    private async void help_Click_1(object sender, RoutedEventArgs e)
    {
        string file = "GamesOfThrones.mp4";
        try
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary; //Or any other folders
            Windows.Storage.StorageFile file =
                await picturesFolder.GetFileAsync(file);
            await Windows.System.Launcher.LaunchFileAsync(file);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }
