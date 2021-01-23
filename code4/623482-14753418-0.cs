    public void saveCheckedItems()
    {
        IList<RadTreeNode> nodeCollection = treeListItems.CheckedNodes;
        foreach (RadTreeNode node in nodeCollection)
        {
            string fileid = node.Value.ToString();
            if (fileid.Length == 12)
            {
                saveTreeChanges(Page.Request.QueryString["ID"], fileid, connectionStr);
            }
        }
    }
