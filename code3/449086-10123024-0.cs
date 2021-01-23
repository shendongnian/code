    // you're expecting only a single node - right?? So use .SelectSingleNode!
    XmlNode node = xx.SelectSingleNode("/RES/MUL/SIN/KEY[@name='need']");
    // if we found the node...
    if(node != null)
    {
        // get "subnode" inside that node
        XmlNode valueNode = node.SelectSingleNode("MUL/SIN/KEY[@name='needID']/VALUE");
        // if we found the <MUL>/<SIN>/<KEY name='needID'>/<VALUE> subnode....
        if(valueNode != null)
        {
            // get the inner text = the text of the XML element...
            string value = valueNode.InnerText;
        }
    }
