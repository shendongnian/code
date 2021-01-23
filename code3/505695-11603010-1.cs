    private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e) {
       Color back = e.Node.BackColor;
       Color fore = e.Node.ForeColor;
       if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected) {
           back = Color.FromKnownColor(KnownColor.Highlight);
           fore = Color.FromKnownColor(KnownColor.HighlightText);
       }
       using (var br = new SolidBrush(back))
       e.Graphics.FillRectangle(br, e.Bounds);
       TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.TreeView.Font, e.Bounds, fore);
    }
