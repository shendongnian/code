    System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load("your file");
    var nodes = doc.Element("calibration").Elements("zoom");
    Dictionary<string, double> myDictionary = new Dictionary<string, double>();
    foreach (System.Xml.Linq.XElement item in nodes)
    {
        var level = item.Attribute("level").Value;
        var val = double.Parse(item.Value);
        myDictionary.Add(level, var);
    }
