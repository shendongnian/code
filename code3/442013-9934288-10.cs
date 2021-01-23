        private void Form1_Load(object sender, EventArgs e)
        {
            string[] fileStrings = new String[]
                {
                    @"\Directory\subDirectory\subsubDir\etc\dir\@@main\branch\version\4",
			        @"\Directory\subDirectory\subsubDir\etc\dir\somefile.txt@@main\branch\version\3",
			        @"\Directory\subDirectory\subsubDir\etc\dir\somefile.txt@@\branch\version\1"
                };
            TreeBuilder treeBuilder = new TreeBuilder();
            treeBuilder.AddItems(fileStrings);
            treeView1.Nodes.Add(treeBuilder.RootNode);
            treeView1.ExpandAll();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            MessageBox.Show(string.Format("Label: {0}\nClearCase path: {1}\nTree path: {2}", selectedNode.Text, selectedNode.Name, selectedNode.FullPath));
        }
