	private static void MarkSelectedNodes(TreeNodeCollection nodes)
	{
		foreach (TreeNode n in nodes)
		{
			if (n.Checked)
				n.BackColor = Color.Black;
			MarkSelectedNodes(n.Nodes);
		}
	}
