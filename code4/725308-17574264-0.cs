    using (XmlReader reader = XmlReader.Create(URL))
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
        foreach(var id in IDList) {
            var nodes = doc.SelectNodes("//idgroup[id='" + id + "']");
            foreach(var node in nodes.Where(x => !string.IsNullOrEmpty(x.ChildNodes[1].ChildNodes[1].InnerText)))
                listValueCollection.Add(value);
        }
    }
