    private void GridSplitterDragCompleted(object sender, DragCompletedEventArgs e)
    {
        // We want the grid splitter to snap in grid of 24 units.
        var excess = (int) FooDataGridRowDefinition.Height.Value % 24;
        if (excess == 0)
            return;
        FooDataGridRowDefinition.Height = new GridLength(FooDataGridRowDefinition.Height.Value - excess);
    }
