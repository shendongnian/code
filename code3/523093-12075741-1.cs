    XmlDocument mainDocument = new XmlDocument();
    mainDocument.Load("toc.xml");
    XmlDocument tempDocument = new XmlDocument();
    tempDocument.Load("part1.xml");
    
    XmlNodeList tempList = tempDocument.GetElementsByTagName("item");
    string id=tempList[0].GetAttribute("id");//gets the id attribute value
    XmlNode mainRoot = mainDocument.DocumentElement; //gets the root node of the main document toc.xml
    XmlNodeList mainList = mainRoot.SelectNodes("/toc");
    XmlNode itemNode = mainList.Item(0).SelectSingleNode(string.Format("/toc/item[@id=\"" + id + "\"]")); //select the item node according to the id attribute value
    XmlNode tempitemNode = tempList.Item(0).SelectSingleNode(string.Format("/toc/item[@id=\"" + id + "\"]/title")); //select the title node of the part1, part2 or part3 files
    
    itemNode.AppendChild(tempitemNode.FirstChild);
    itemNode.AppendChild(tempitemNode.LastChild);
    
    mainDocument.Save("toc.xml");
