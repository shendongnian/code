    bool Expanded = false; 
    // The event subscription method (for a button click)
    private void ButtonExpand__Click(object sender, RoutedEventArgs e)
    {
        Expanded = !Expanded;
        Style Style = new Style
        {
            TargetType = typeof(TreeViewItem)
        };
    
        Style.Setters.Add(new Setter(TreeViewItem.IsExpandedProperty, Expanded));
        TreePeople.ItemContainerStyle = Style;
    }
