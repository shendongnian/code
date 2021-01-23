        public TreeViewItem root;
        public MainWindow()
        {
            InitializeComponent();
            root = new TreeViewItem
            {
                Header = "Customers"
            };
            treeView.Items.Add(root);
            addNode("John");
            addNode("Peter");
            addNode("Vanesa.New");
            addNode("Josh");
            addNode("Josh.New");
            addNode("Josh.New.Under");
        }
        private void addNode(string values)
        {
            var n = root;
            foreach (var val in values.Split('.'))
            {
                var isNew = true;
                foreach (var existingNode in n.Items)
                {
                    if (((TreeViewItem)existingNode).Header.ToString() == val)
                    {
                        n = (TreeViewItem)existingNode;
                        isNew = false;
                    }
                }
                if (isNew)
                {
                    var newNode = new TreeViewItem
                    {
                        Header = val
                    };
                    n.Items.Add(newNode);
                    n = newNode;
                }
            }
        }
