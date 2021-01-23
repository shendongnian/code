    foreach (XmlNode chkNode in nodes)
    {                
        string currentName = "Test 1";
        if (!nameDict.ContainsKey(currentName))
        {
            XmlNode parent = chkNode.ParentNode;
            parent.ParentNode.RemoveChild(parent);
        }
    }
