    Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
    Sitecore.Data.Items.Item sampleItem = master.GetItem("/sitecore/media library/Files/testxml");
    Sitecore.Data.Items.Item sampleMedia = new Sitecore.Data.Items.MediaItem(sampleItem);
    XmlDocument xmdDoc = new XmlDocument();
    xmdDoc.Load(MediaManager.GetMedia(sampleMedia).GetStream().Stream);
