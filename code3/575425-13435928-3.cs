    using System.Net;
    using System.Xml;
    // ...
    public void Images()
    {
        WebClient x = new WebClient();
        string source = x.DownloadString(@"http://www.google.com");
        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        document.Load(source);
        XmlDocument output = new XmlDocument();
        XmlElement imgElements = output.CreateElement("ImgElements");
        output.AppendChild(imgElements);
        foreach(HtmlNode link in document.DocumentElement.SelectNodes("//img[contains(@src, '_412s.jpg')]")
        {
            XmlElement img = output.CreateElement(link.Name);
            foreach(HtmlAttribute a in link.Attributes)
            {
                img.SetAttribute(a.Name, a.Value)
            }
            imgElements.AppendChild(img);
        }
        output.Save(@"C:\test.xml");
    }
