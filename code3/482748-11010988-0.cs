    using System;
    using System.Windows.Forms;
    
    class MyTreeView : TreeView {
        protected override void OnAfterCheck(TreeViewEventArgs e) {
            if (checking) return;
            checking = true;
            if (e.Node.Checked && (Control.ModifierKeys & Keys.Control) == Keys.Control) {
                uncheckNodes(this.Nodes, e.Node);
            }
            checking = false;
            base.OnAfterCheck(e);
        }
    
        private void uncheckNodes(TreeNodeCollection nodes, TreeNode except) {
            foreach (TreeNode node in nodes) {
                if (node != except) node.Checked = false;
                uncheckNodes(node.Nodes, except);
            }
        }
        private bool checking;
    }
