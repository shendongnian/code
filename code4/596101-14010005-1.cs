    public void DeleteDevice(IEnumerable<Device> devices)
    {
        var uris = new HashSet<string>(devices.Select(x => x.URI));
        var doc = XDocument.Load(FULL_PATH);
        doc.Element("Settings")
           .Elements("Device")
           .Where(c => uris.Contains((string)c.Element("sipUri")))
           .Remove();
        doc.Save(PATH);
    }
