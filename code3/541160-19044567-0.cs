    private void down_click(object sender, RoutedEventArgs e)
    {
        if (this.lbItems.SelectedIndex != -1) //Added condition
        {
            var selectedIndex = this.lbItems.SelectedIndex;
            if (selectedIndex + 1 < this.ListItems.Count)
            {
                var itemToMoveDown = this.ListItems[selectedIndex];
                this.ListItems.RemoveAt(selectedIndex);
                this.ListItems.Insert(selectedIndex + 1, itemToMoveDown);
                this.lbItems.SelectedIndex = selectedIndex + 1;
            }
        }
    }
