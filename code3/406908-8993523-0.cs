    public void btnGeneral_Click(object sender, RoutedEventArgs e)
    {   
        PanelMainContent.Children.Clear();
        if (e.OriginalSource is MenuItem)
        {
            MenuItem menuItem = (MenuItem)e.OriginalSource;
            PanelMainWrapper.Header = menuItem.Header;
            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            PanelMainContent.Children.Add(_userControls[menuItem.Tag.ToString()]);
        }
        if (e.OriginalSource is Button)
        {
            Button button = (Button)e.OriginalSource;
            PanelMainWrapper.Header = button.Content;
            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            PanelMainContent.Children.Add(_userControls[button.Tag.ToString()]);
        }
    }
