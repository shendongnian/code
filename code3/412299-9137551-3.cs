    private async void LayoutRoot_Tapped(object sender, Windows.UI.Xaml.Input.TappedEventArgs e)
    {
        if (devices != null && !switchingMedia)
        {
            currentDevice = (currentDevice + 1) % devices.Count;
            switchingMedia = true;
            await InitializeWebCam();
            switchingMedia = false;
        }
    }
