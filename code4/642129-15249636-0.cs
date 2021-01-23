    public static void Search(ArrayList nodeIds, ArrayList values)
    {
        XDocument doc = XDocument.Load("Options.xml");
        foreach (XElement option in doc.Descendants("BasicOptions"))
        {
            foreach (string nodeId in nodeIds)
            {
                if (option.Attribute("id").Value == nodeId)
                {
                    var nodes = option.Nodes().ToList();
                    for (int i = 0; i < nodes.Count && i < values.Count; i++)
                    {
                        XElement node = (XElement)nodes[i];
                        node.Value = values[i].ToString();
                    }
                }
            }
        }
        doc.Save("Options.xml");
    }
