    // System.Web.UI.WebControls.TreeNodeCollection
    /// <summary>Empties the <see cref="T:System.Web.UI.WebControls.TreeNodeCollection" /> object.</summary>
    public void Clear()
    {
	if (this.Count == 0)
	{
		return;
	}
	if (this._owner != null)
	{
		TreeView owner = this._owner.Owner;
		if (owner != null)
		{
			if (owner.CheckedNodes.Count != 0)
			{
				owner.CheckedNodes.Clear();
			}
			for (TreeNode treeNode = owner.SelectedNode; treeNode != null; treeNode = treeNode.Parent)
			{
				if (this.Contains(treeNode))
				{
					owner.SetSelectedNode(null);
					break;
				}
			}
		}
	}
	foreach (TreeNode current in this._list)
	{
		current.SetParent(null);
	}
	this._list.Clear();
	this._version++;
	if (this._isTrackingViewState)
	{
		this.Log.Clear();
	}
	this.Log.Add(new TreeNodeCollection.LogItem(TreeNodeCollection.LogItemType.Clear, 0, this._isTrackingViewState));
    }
