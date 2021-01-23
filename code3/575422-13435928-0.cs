    public void Images()
    {
        WebClient x = new WebClient();
        string source = x.DownloadString(@"http://www.google.com");
        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        document.Load(source);
        List<string> images = new List<string>();
        foreach(HtmlNode link in document.DocumentElement.SelectNodes("//img[contains(@src, 'name_412s.jpg')]")
        {
            images.Add(link["src"]);
        }
        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
        using TextWriter writer = new StreamWriter(@"C:\test.xml")
        {
            serializer.Serialize(writer, images);
        }
    }
