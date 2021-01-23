    public static void BuildDataTable(XmlNode node)
    {
        XmlNode nodWorking;
        if (node.NodeType == XmlNodeType.Element)
        {
            if (node.HasChildNodes)
            {
                nodWorking = node.FirstChild;
                while (nodWorking != null)
                {
                    if (nodWorking.NodeType != XmlNodeType.Element)
                    {
                        if(!dictname.ContainsKey(node.ParentNode.Name.ToString() + node.Name.ToString()))
                        dictname[node.ParentNode.Name.ToString() + node.Name.ToString()] = node.InnerText;
                        else
                            dictname[node.ParentNode.Name.ToString() + node.Name.ToString()] = dictname[node.ParentNode.Name.ToString() + node.Name.ToString()] +","+node.InnerText;
                        
                    }
                    BuildDataTable(nodWorking);
                    nodWorking = nodWorking.NextSibling;
                }
            }
        }
    }
