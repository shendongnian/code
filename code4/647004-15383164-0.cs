    public XmlNode makeXPath(XmlDocument doc, string xpath, string innertext)
        {
            string[] partsOfXPath = xpath.Split('/');
            XmlNode node = null;
            if (doc.SelectSingleNode(xpath) != null) {
                //get the parent
                node = doc.SelectSingleNode(string.Join("/", partsOfXPath, 0, partsOfXPath.Length-1));
                node = node.AppendChild(doc.CreateElement(partsOfXPath[newXpathPos]));
                node.InnerText = innertext.TrimStart(' ');
            }
            else {
                for (int xpathPos = partsOfXPath.Length; xpathPos > 0; xpathPos--)
                {
                    string subXpath = string.Join("/", partsOfXPath, 0, xpathPos);
                    node = doc.SelectSingleNode(subXpath);
                    if (node != null)
                    {
                        // append new descendants
                        for (int newXpathPos = xpathPos; newXpathPos < partsOfXPath.Length; newXpathPos++)
                        {
                            node = node.AppendChild(doc.CreateElement(partsOfXPath[newXpathPos]));
    
                        }
                        break;
                    }
                }
                node.InnerText = innertext.TrimStart(' ');
            }
            return node;
        }
