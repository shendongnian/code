    TreeViewItem Item = new TreeViewItem();
	StackPanel HeaderLayout = new StackPanel() { Orientation = Orientation.Horizontal };
	HeaderLayout.Children.Add(new Image());
	HeaderLayout.Children.Add(new TextBlock() { Text = "tv item" });
	Item.Header = HeaderLayout;
