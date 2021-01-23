    XElement doc = XElement.Load("~/App_Data/test_xml.xml");
    TreeNode root = new TreeNode("FEATURES");
    foreach (XElement state in doc.Descendants("FEATURE"))
    {
        TreeNode feature = new TreeNode(state.Attribute("NAME").Value);
        foreach (XElement region in state.Descendants("USER"))
        {
            TreeNode user =  new TreeNode(region.Attribute("NAME").Value);
            foreach (XElement area in region.Descendants("NAME"))
            {
                user.ChildNodes.Add(new TreeNode(area.Attribute("NAME").Value));
            }
            feature.ChildNodes.Add(user);
        }
        root.ChildNodes.Add(feature);
    }
    treeview.Nodes.Add(root);
