    public class LevelXmlReader
    {
        public string[] backgroundData;
        public string[] wallData;
    
        LevelXmlReader()
        {
            XDocument doc = XDocument.Load(@"Level/Level01.xml");
            foreach (XElement layer in doc.Element("map").Descendants("layer"))
            {
                var layName = layer.Attribute("name").Value;
                switch (layName)
                {
                    case "background":
                        backgroundData = layer.Element("data").Value.Split(',');
                        break;
                    case "walls":
                        wallData = layer.Element("data").Value.Split(',');
                        break;
                }
            }
        }
    }
