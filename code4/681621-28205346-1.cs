    private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                processClick(e);
            }
        }
        private void processClick(System.Windows.Forms.MouseEventArgs e)
        {
            System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);
            TreeNode node = treeView1.GetNodeAt(p);
            treeView1.SelectedNode = node;
        }
