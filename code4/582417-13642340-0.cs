        private TreeViewItem GetTreeView(string uid, string text, string imagePath)
        {
            TreeViewItem item = new TreeViewItem();
            item.Uid = uid;
            item.IsExpanded = false;
            // create stack panel
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            // create Image
            Image image = new Image();
            image.Source = new BitmapImage
                (new Uri("pack://application:,,/Images/" + imagePath));
            image.Width = 16;
            image.Height = 16;
            // Label
            Label lbl = new Label();
            lbl.Content = text;
            // Add into stack
            stack.Children.Add(image);
            stack.Children.Add(lbl);
            // assign stack to header
            item.Header = stack;
            return item;
        }
