    protected AudioVideoCaptureDevice Device { get; set; }
    private async void ButtonTurnOn_Click(object sender, RoutedEventArgs e)
    {
        var sensorLocation = CameraSensorLocation.Back;
        try
        {
            if (this.Device == null)
            {
                // get the AudioViceoCaptureDevice
                this.Device = await AudioVideoCaptureDevice.OpenAsync(sensorLocation,
                AudioVideoCaptureDevice.GetAvailableCaptureResolutions(sensorLocation).First());
            }
            // turn flashlight on
            var supportedCameraModes = AudioVideoCaptureDevice
                .GetSupportedPropertyValues(sensorLocation, KnownCameraAudioVideoProperties.VideoTorchMode);
            if (supportedCameraModes.ToList().Contains((UInt32)VideoTorchMode.On))
            {
                this.Device.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.On);
                // set flash power to maxinum
                this.Device.SetProperty(KnownCameraAudioVideoProperties.VideoTorchPower,
                    AudioVideoCaptureDevice.GetSupportedPropertyRange(sensorLocation, KnownCameraAudioVideoProperties.VideoTorchPower).Max);
            }
            else
            {
                turnWhiteScreen(true);
            }
        }
        catch (Exception ex)
        {
            // Flashlight isn't supported on this device, instead show a White Screen as the flash light
            turnWhiteScreen(true);
        }
    }
