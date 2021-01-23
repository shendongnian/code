    private void Box_MouseMove(object sender, MouseEventArgs e)
    {
        if (draggedBox != null)
        {
            ...
            RefreshLinesPositions();
        }
    }
