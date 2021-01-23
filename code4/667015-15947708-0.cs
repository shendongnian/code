    string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <calibration>
    <zoom level=""250"">0,110050251256281</zoom>
    <zoom level=""150"">0,810050256425628</zoom>
    <zoom level=""850"">0,701005025125628</zoom>
    <zoom level=""550"">0,910050251256281</zoom>
    </calibration>";
    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
    xmlDoc.LoadXml(xml);
    var nodes = xmlDoc.SelectNodes("calibration/zoom");
    var dicNodes = new Dictionary<string,string>();
    foreach (System.Xml.XmlNode node in nodes)
    {
        dicNodes.Add(node.Attributes["level"].Value, node.InnerText);
    }
