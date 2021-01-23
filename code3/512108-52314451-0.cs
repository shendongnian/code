    public string ReadAllNodes(XmlNode node)
    {
        if (node.ChildNodes.Count > 0)
        {
            foreach (XmlNode subNode in node)
            {
                //Recursion
                ReadAllNodes(subNode);
            }
        }
        else //Get the node value.
        {
            finalText = finalText + node.InnerText + System.Environment.NewLine;
        }
        return finalText;
    }
