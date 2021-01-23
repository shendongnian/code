	protected override void OnAfterSelect(TreeViewEventArgs e)
	{
		base.OnAfterSelect(e);
		if (e.Node.Nodes.Count != 0)
		{
			this.SelectedNode = null;
		}
	}
