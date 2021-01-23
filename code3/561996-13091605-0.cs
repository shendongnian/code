        private void timer1_Tick(object sender, EventArgs e) {
            var node = treeView1.SelectedNode;
            if (node == null || !node.IsVisible) panel1.Visible = false;
            else {
                panel1.Visible = true;
                var nodepos = treeView1.PointToScreen(node.Bounds.Location);
                var panelpos = panel1.Parent.PointToClient(nodepos);
                panel1.Top = panelpos.Y;
            }
        }
