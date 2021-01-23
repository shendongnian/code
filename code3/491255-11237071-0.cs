        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel1.Controls.Clear();
            UserControl uc = new MyUserControl();
            uc.DataToShow = (MyObject)treeView1.SelectedNode.Tag;
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }
