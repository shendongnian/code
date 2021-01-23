    private void ButtonTurnOff_Click(object sender, RoutedEventArgs e)
    {
        var sensorLocation = CameraSensorLocation.Back;
        try
        {
            // turn flashlight on
            var supportedCameraModes = AudioVideoCaptureDevice
                .GetSupportedPropertyValues(sensorLocation, KnownCameraAudioVideoProperties.VideoTorchMode);
            if (this.Device != null && supportedCameraModes.ToList().Contains((UInt32)VideoTorchMode.Off))
            {
                this.Device.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.Off);
            }
            else
            {
                turnWhiteScreen(false);
            }
        }
        catch (Exception ex)
        {
            // Flashlight isn't supported on this device, instead show a White Screen as the flash light
            turnWhiteScreen(false);
        }
    }
