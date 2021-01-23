        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            this.BeginInvoke(new Action(() => afterAfterEdit(e.Node)));
        }
        private void afterAfterEdit(TreeNode node) {
            string txt = node.Text;   // Now it is updated
            // etc..
        }
