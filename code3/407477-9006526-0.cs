    foreach (XmlNode node in Xdoc.SelectNodes("//" + Childnode))
    {
        bool nodeIsGood = true;
        for (int i = 0; i < ComparableAttributes.Count(); i++)
        {
            if (node.Attributes[ComparableAttributes[i]].Value 
                             != ComparableAttributesValue[i])
            {
                // the attribute doesn't have the required value
                // so this node is no good
                nodeIsGood = false;
                // and there's no point checking any more attributes
                break;
            }
        }
        if (nodeIsGood)
            xmlList.Add(node);
    }
