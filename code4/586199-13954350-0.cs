    void GridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var ctrl = this.ItemContainerGenerator.ContainerFromItem(e.ClickedItem);
        ((Control)ctrl).Visibility = Visibility.Collapsed;
        ((Control)ctrl).Visibility = Visibility.Visible;
    }
