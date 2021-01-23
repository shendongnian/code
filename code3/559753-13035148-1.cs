    private async void pushpinTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        PushPin tappedpin = sender as PushPin;  // gets the pin that was tapped
        if(null == tappedpin) return;           // null check to prevent bad stuff if it wasn't a pin.
        var x = MapLayer.GetPosition(tappedpin);
        MessageDialog dialog = new MessageDialog("You are here " + x.Latitude + " " + x.Longitude);
        await dialog.ShowAsync();
    }
