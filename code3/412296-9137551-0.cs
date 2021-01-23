    MediaCapture mediaCapture;
    DeviceInformationCollection devices;
    int currentDevice = 0;
    bool switchingMedia = false;
    
    private async void LayoutRoot_Tapped(object sender, Windows.UI.Xaml.Input.TappedEventArgs e)
    {
        if (devices != null)
        {
            currentDevice = (currentDevice + 1) % devices.Count;
            InitializeWebCam();
        }
    }
    
    private async void InitializeWebCam()
    {
        if (devices == null)
        {
            devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            ListDeviceDetails();
        }
    
        if (switchingMedia)
            return;
        switchingMedia = true;
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
