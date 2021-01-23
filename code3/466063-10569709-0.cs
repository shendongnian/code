    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (this.ListBox.SelectedItems.Count > 0)
        {
            this.BottomAppBar.IsSticky = true;
            this.BottomAppBar.IsOpen = true;
        }
        else
        {
            this.BottomAppBar.IsOpen = false;
            this.BottomAppBar.IsSticky = false;
        }
        
        // Or the following if you wish...
        // this.BottomAppBar.IsOpen = this.BottomAppBar.IsSticky = this.ListView.SelectedItems.Count > 0;
    }
