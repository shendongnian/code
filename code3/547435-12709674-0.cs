    // '' <summary>
    // '' When Left Mouse button is pressed, remember where the mouse move start
    // '' </summary>
    private void EditedItems_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
        StartPoint = Mouse.GetPosition(this);
    }
    
    // '' <summary>
    // '' When mouse move, update the highlight of the selected items.
    // '' </summary>
    private void EditedItems_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e) {
        if ((StartPoint == null)) {
            return;
        }
        PointWhereMouseIs = Mouse.GetPosition(this);
        Rect SelectedRect = new Rect(StartPoint, PointWhereMouseIs);
        if (((SelectedRect.Width < 20) 
                    && (SelectedRect.Height < 20))) {
            return;
        }
        //  show the rectangle again
        Canvas.SetLeft(SelectionRectangle, Math.Min(StartPoint.X, PointWhereMouseIs.X));
        Canvas.SetTop(SelectionRectangle, Math.Min(StartPoint.Y, PointWhereMouseIs.Y));
        SelectionRectangle.Width = Math.Abs((PointWhereMouseIs.X - StartPoint.X));
        SelectionRectangle.Height = Math.Abs((PointWhereMouseIs.Y - StartPoint.Y));
        foreach (CheckBox ThisChkBox in EditedItems.Children) {
            object rectBounds = VisualTreeHelper.GetDescendantBounds(ThisChkBox);
            Vector vector = VisualTreeHelper.GetOffset(ThisChkBox);
            rectBounds.Offset(vector);
            if (rectBounds.IntersectsWith(SelectedRect)) {
                ((TextBlock)(ThisChkBox.Content)).Background = Brushes.LightGreen;
            }
            else {
                ((TextBlock)(ThisChkBox.Content)).Background = Brushes.Transparent;
            }
        }
    }
    
    // '' <summary>
    // '' When Left Mouse button is released, change all CheckBoxes values. (Or do nothing if it is a small move -->
    // '' click will be handled in a standard way.)
    // '' </summary>
    private void EditedItems_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) {
        PointWhereMouseIs = Mouse.GetPosition(this);
        Rect SelectedRect = new Rect(StartPoint, PointWhereMouseIs);
        StartPoint = null;
        SelectionRectangle.Opacity = 0;
        //  hide the rectangle again
        if (((SelectedRect.Width < 20) 
                    && (SelectedRect.Height < 20))) {
            return;
        }
        foreach (CheckBox ThisEditedItem in EditedItems.Children) {
            object rectBounds = VisualTreeHelper.GetDescendantBounds(ThisEditedItem);
            Vector vector = VisualTreeHelper.GetOffset(ThisEditedItem);
            rectBounds.Offset(vector);
            if (rectBounds.IntersectsWith(SelectedRect)) {
                ThisEditedItem.IsChecked = !ThisEditedItem.IsChecked;
            }
            ((TextBlock)(ThisEditedItem.Content)).Background = Brushes.Transparent;
        }
    }
