    MediaCapture mediaCapture;
    DeviceInformationCollection devices;
    int currentDevice = 0;
    bool switchingMedia = false;
    
    private async void LayoutRoot_Tapped(object sender, Windows.UI.Xaml.Input.TappedEventArgs e)
    {
        if (devices != null)
        {
            InitializeWebCam();
        }
    }
    
    private async void InitializeWebCam()
    {
        if (switchingMedia)
            return;
        switchingMedia = true;
        if (devices == null)
        {
            devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            ListDeviceDetails();
        }
        else
        {
            currentDevice = (currentDevice + 1) % devices.Count;
        }
    
        if (mediaCapture != null)
        {
            await mediaCapture.StopPreviewAsync();
            this.captureElement.Source = null;
        }
    
        mediaCapture = new MediaCapture();
        await mediaCapture.InitializeAsync(
            new MediaCaptureInitializationSettings
            {
                VideoDeviceId = devices[currentDevice].Id
            });
    
        this.captureElement.Source = mediaCapture;
        await mediaCapture.StartPreviewAsync();
        switchingMedia = false;
    }
