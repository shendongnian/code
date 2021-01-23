    private void Window_ContentRendered(object sender, EventArgs e)
    {
        TreeViewItem childNode = new TreeViewItem()
        {
            Header = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                 Children =
                 {
                     new Border
                     {
                         Width = 12,
                         Height = 14,
                         Background = Brushes.Yellow, // Set background here
                     },
                     new Label 
                     {
                         Content = "Child1", 
                         Background = Brushes.Pink, // Set background here
                     }
                 }
            }
        };
        MyTreeView.Items.Add(childNode);
    }
