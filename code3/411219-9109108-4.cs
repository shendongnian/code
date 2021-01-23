    public void showToolTip(object sender, DependencyPropertyChangedEventArgs e)
    {
        //Get tooltip from sender.
        ToolTip tt = (ToolTip)(sender as Control).ToolTip;
        //Places the Tooltip under the control rather than at the mouse position
        tt.PlacementTarget = (UIElement)sender;
        tt.Placement = PlacementMode.Right;
        tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
        //Shows tooltip if KeyboardFocus is within.
        tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
    }
