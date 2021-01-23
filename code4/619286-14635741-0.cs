    private async void MILoadLogFile_Click(object sender, RoutedEventArgs e)
    {
        //...
        await Task.Factory.StartNew(async () =>
        {
            await myLogSession.LoadfromFileAsync(oFD.FileName);
        });
    }
