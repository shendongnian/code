    using (SPSite Site = new SPSite(SPContext.Current.Site.Url + "/UberWiki"))
    {
        using (SPWeb currentWeb = Site.OpenWeb())
        {
            // set the tree view properties
            SPList list = currentWeb.GetList(currentWeb.Url+"/Lists/Pages");
            SPFieldChoice field = (SPFieldChoice)list.Fields["Categories"];
            treeView = new System.Web.UI.WebControls.TreeView();
            
            // Add root nodes
            foreach (string str in field.Choices)
            {
                rootNode = new System.Web.UI.WebControls.TreeNode(str);
                treeView.Nodes.Add(rootNode);                        
            }
            // Add child nodes
            foreach (SPListItem rows in list.Items)
            {
                childNode = new System.Web.UI.WebControls.TreeNode(rows["Title"].ToString());
                treeView.FindNode(rows["Categories"].ToString()).ChildNodes.Add(childNode);
            }
        }
        this.Controls.Add(treeView);
        base.CreateChildControls();
    }
