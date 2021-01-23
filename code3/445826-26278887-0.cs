	treeView.HideSelection = false;
	treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
	treeView.DrawNode += (o, e) =>
	{
		if (!e.Node.TreeView.Focused && e.Node == e.Node.TreeView.SelectedNode)
		{
			Font treeFont = e.Node.NodeFont ?? e.Node.TreeView.Font;
			e.Graphics.FillRectangle(Brushes.Gray, e.Bounds);
			ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, SystemColors.HighlightText, SystemColors.Highlight);
			TextRenderer.DrawText(e.Graphics, e.Node.Text, treeFont, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
		}
		else
			e.DrawDefault = true;
	};
	treeView.MouseDown += (o, e) =>
	{
		TreeNode node = treeView.GetNodeAt(e.X, e.Y);
		if (node != null && node.Bounds.Contains(e.X, e.Y))
			treeView.SelectedNode = node;
	};
