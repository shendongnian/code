    treeView.HideSelection = false;
    treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
    treeView.DrawNode += (o, e) =>
    {
        if (e.Node != e.Node.TreeView.SelectedNode)
        {
            e.DrawDefault = true;
            return;
        }
        Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
        Rectangle r = e.Bounds;
        r.Offset(0, 1);
        if (e.Node.TreeView.Focused)
        {
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, r, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
        }
        else
        {
            e.Graphics.FillRectangle(Brushes.Gray, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, r, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
        }
    };
    treeView.MouseDown += (o, e) =>
    {
        TreeNode node = treeView.GetNodeAt(e.Location);
        if (node != null && node.Bounds.Contains(e.Location)) treeView.SelectedNode = node;
    };
