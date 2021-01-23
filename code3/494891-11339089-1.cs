    XmlDocument document; //init and load it
    static List<String> GetLeavesText(int pLevel /* 2 */, string pText /* AA */)
    {
        var result = new List<String>();
        //loaded document
        var nodeList = document.SelectNodes(String.Format(@"//P{0}[@Text='{1}']//L/@Text", pLevel, pText));
        if (nodeList != null)
            foreach (XmlNode xmlNode in nodeList)
            {
                result.Add(xmlNode.InnerText);
            }
        return result;
    }
