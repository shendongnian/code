    private void hubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        //vibrate
        if (Settings.EnableVibration.Value)
        {
            VibrateController.Default.Start(TimeSpan.FromMilliseconds(40));
        }
        TileItem item = sender as TileItem;
        this.NavigationService.Navigate(new Uri(item.NavigationUri, UriKind.Relative));
    }
