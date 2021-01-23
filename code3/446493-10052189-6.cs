    [TestMethod]
    public void ParseXmlLinq()
    {
        XDocument xdoc = XDocument.Parse(this.mockXml);
    
        XElement app = xdoc.Root.Elements()
            .FirstOrDefault(e => e.Name == XName.Get("AppObject", "http://tempuri.org/"));
    
        Assert.IsNotNull(app, "<AppObject> not found");
    
        XElement img = app.Elements()
            .FirstOrDefault(x => x.Name == XName.Get("Image", "http://tempuri.org/"));
    
        Assert.IsNotNull(img, "<Image> not found");
        Assert.AreEqual("StoreApp.png", img.Value);
    }
