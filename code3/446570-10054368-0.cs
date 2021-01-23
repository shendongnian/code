        private void treeView_DragOver(object sender, DragEventArgs e) {
            var tree = (TreeView)sender;
            var pos = tree.PointToClient(new Point(e.X, e.Y));
            var hit = tree.HitTest(pos);
            if (hit.Node == null) e.Effect = DragDropEffects.None;
            else {
                tree.SelectedNode = hit.Node;
                tree.SelectedNode.Expand();        // Optional
                e.Effect = DragDropEffects.Copy;
            }
        }
