    // define XPath
    string xpath = "/RES/MUL/SIN/KEY[@name='need']/MUL/SIN/KEY[@name='needID']/VALUE";
    // you're expecting only a single node - right?? So use .SelectSingleNode!
    XmlNode node = xx.SelectSingleNode(xpath);
    // if we found the node...
    if(node != null)
    {
        // get the inner text = the text of the XML element...
        string value = node.InnerText;
    }
