    [TestMethod]
    public void XElementWriterTest()
    {
        var xelement = new XElement("test");
        const string newXML = @"<some raw='xml' />";
        var child = XElement.Parse(newXML);
        xelement.Add(child);
        Assert.AreEqual(xelement.ToString(SaveOptions.DisableFormatting), @"<test><some raw=""xml"" /></test>");
    }
