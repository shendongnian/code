    private readonly ObservableCollection<string> devices = new ObservableCollection<string>();
    public IEnumerable<string> Devices { get { return devices; } }
    private void deviceSelector_DropDownOpened(object sender, EventArgs e)
    {
        devices.Clear();
        devices.Add("Device 1");
        devices.Add("Device 2");
    } 
