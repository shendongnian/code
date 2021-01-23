        TabControlBind tabControlBinder;
        ObservableList<TreeNodeItem> treeNodeItems;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // This will automatically update the TabControl
            treeNodeItems.Add(new TreeNodeItem(new NTree<string>() { data = "Test3" }));
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Create a new list object an add items to it
            treeNodeItems = new ObservableList<TreeNodeItem>();
            treeNodeItems.Add(new TreeNodeItem(new NTree<string>() { data = "Test" }));
            treeNodeItems.Add(new TreeNodeItem(new NTree<string>() { data = "Test2" }));
            // Create a new instance of the TabControlBind class, set it to our TabControl
            tabControlBinder = new TabControlBind(tabControl);
            tabControlBinder.TreeNodeItems = treeNodeItems;
        }
