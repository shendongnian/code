    XElement xdevices = XElement.Load(file.FullName);
    Device[] devices = xdevices.GetEnumerable("device", xdevice => new Device(xdevice)).ToArray();
    var myDevice = devices
         .Where(d => d.Name == App.CurrentDeviceName 
                  && d.Ip == App.CurrentIp);
    foreach (Device device in myDevice)
    {
        string name = device.Name;
        foreach (Device.Source source in device.Sources)
        {
            string sourceName = source.Name;
        }
        device.CustomName = "new name";
    }
    xdevices.Save(file.FullName);
