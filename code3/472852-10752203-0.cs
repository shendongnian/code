    tree_view.Items.Add(GetTreeView("text"));
    
    private TreeViewItem GetTreeView(string text)
    {
        TreeViewItem newTreeViewItem = new TreeViewItem();
    
        // create stack panel
        StackPanel stack = new StackPanel();
        stack.Orientation = Orientation.Horizontal;
    
        // create Image
        Image image = new Image();
        image.Source = new BitmapImage(new Uri(@"/ComponentName;component/Resources/Images/warning.png", UriKind.Relative));
    
        // Label
        Textblock lbl = new Textblock();
        lbl.Text = text;
        lbl.TextWrapping = TextWrapping.Wrap;
        lbl.Width = 139;
    
        // Add into stack
        stack.Children.Add(image);
        stack.Children.Add(lbl);
    
        // assign stack to header
        newTreeViewItem.Header = stack;
    
        return newTreeViewItem;
    }
