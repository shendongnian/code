    private void TreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed) return;
        TreeViewItem item = e.Source as TreeViewItem;
        if (item != null)
        {
            DataObject dataObject = new DataObject();
            dataObject.SetData(DataFormats.StringFormat, item.Header);
            DragDrop.DoDragDrop(item, dataObject, DragDropEffects.Move);
        }
    }
