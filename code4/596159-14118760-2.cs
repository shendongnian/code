    var obj = new NewsResponse { ContentItems = new List<News> {
        new News { A = 1, B = 2 } } };
    var sw = new StringWriter();
    using (var xw = System.Xml.XmlWriter.Create(sw))
    {
        var ser = new XmlSerializer(obj.GetType());
        ser.Serialize(xw, obj);
    }
    string xml = sw.ToString();
