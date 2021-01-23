    var client = new BluetoothClient();
    var dlg = new SelectBluetoothDeviceDialog();
    DialogResult result = dlg.ShowDialog(this);
    if (result != DialogResult.OK)
    {
        return;
    }
    BluetoothDeviceInfo device = dlg.SelectedDevice;
    BluetoothAddress addr = device.DeviceAddress;
    Console.WriteLine(device.DeviceName);
    BluetoothSecurity.PairRequest(addr, "Whatever pin");
    device.SetServiceState(BluetoothService.HumanInterfaceDevice, true);
    Thread.Sleep(100); // Just in case
    if (device.InstalledServices.Length == 0)
    {
        // I wouldn't know why it doesn't install the service
    }
    client.Connect(addr, BluetoothService.HumanInterfaceDevice);
