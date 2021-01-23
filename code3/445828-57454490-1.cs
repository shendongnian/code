    treeView.HideSelection = false;
    treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
    treeView.DrawNode += (o, e) =>
    {
        if (e.Node == e.Node.TreeView.SelectedNode)
        {
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Rectangle r = e.Bounds;
            r.Offset(0, 1);
            Brush brush = e.Node.TreeView.Focused ? SystemBrushes.Highlight : Brushes.Gray;
            e.Graphics.FillRectangle(brush, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, r, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
        }
        else
            e.DrawDefault = true;
    };
    treeView.MouseDown += (o, e) =>
    {
        TreeNode node = treeView.GetNodeAt(e.Location);
        if (node != null && node.Bounds.Contains(e.Location)) treeView.SelectedNode = node;
    };
