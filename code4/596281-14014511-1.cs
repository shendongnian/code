        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeNode tn = treeView1.GetNodeAt(e.Location);
                myMenu.tn = tn;
            }
        }
