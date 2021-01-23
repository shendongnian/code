    private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        ContentControl designerItem = this.DataContext as ContentControl;
            double left = Canvas.GetLeft(designerItem);
            double top = Canvas.GetTop(designerItem);
            Canvas.SetLeft(designerItem, left + e.HorizontalChange);
            Canvas.SetTop(designerItem, top + e.VerticalChange);
    }
