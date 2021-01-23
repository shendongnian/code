        public ObservableCollection<TreeViewItem> Tree { get; set; }
        public static TreeViewItem Item = new TreeViewItem {Header = "MainTreeViewItem"};
        public static TreeViewItem Item2 = new TreeViewItem {Header = "MainTreeViewItem"};
        ContextMenu contextMenu = new ContextMenu { Background = Brushes.White, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1) };
        MenuItem addItem = new MenuItem() { Header = "Add..." }; //Add & Delete MenuItems
        MenuItem deleteItem = new MenuItem() { Header = "Delete..." };
        public MainWindow()
        {
            Tree = new ObservableCollection<TreeViewItem>();
            //Add MenuItems to TreeView ContextMenus
            contextMenu.Items.Add(addItem);
            contextMenu.Items.Add(deleteItem);
            Item.ContextMenu = contextMenu;
            Item2.ContextMenu = contextMenu;
            Tree.Add(Item);
            Tree.Add(Item2);
        }
