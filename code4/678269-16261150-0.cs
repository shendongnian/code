    using System.Xml.Linq;
    using Windows.ApplicationModel;
    using Windows.Storage;
    private async void GetInfo(object sender, RoutedEventArgs e)
    {
        StorageFile file = await Package.Current.InstalledLocation.GetFileAsync("AppxManifest.xml");
        string manifestXml = await FileIO.ReadTextAsync(file);
        XDocument doc = XDocument.Parse(manifestXml);
        XNamespace packageNamespace = "http://schemas.microsoft.com/appx/2010/manifest";
        var displayName = (from name in doc.Descendants(packageNamespace + "DisplayName")
                           select name.Value).First();
        var publisherDsplName = (from publisher in doc.Descendants(packageNamespace + "PublisherDisplayName")
                                 select publisher.Value).First();
        string output = "DisplayName: " + displayName + ", PublisherDisplayName: " + publisherDsplName;
        txtBlock.Text = output;
    }
