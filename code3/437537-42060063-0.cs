    private async void btnMute_ButtonClick(object sender, EventArgs e)
    {
        var audioController = new CoreAudioController();
        var devices = await audioController.GetDevicesAsync(DeviceType.Capture, DeviceState.Active);
        var device = devices.FirstOrDefault(x => x.IsDefaultDevice);
        if(device != null) {
            await device.SetMuteAsync(!device.IsMuted);
        }
    }
