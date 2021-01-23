    private void DragDropTarget_DragEnter(object sender, Microsoft.Windows.DragEventArgs e)
    {
        var sw = sender as DataGridDragDropTarget;
        if (sw == null)
        {
            return;
        }
        if(GetAssignmentCondition(e))
        {
            // TODO: Show link-icon
            e.Effects = DragDropEffects.Link;
        }
        else
        {
            // TODO: Show drop-disabled-icon
            e.Effects = DragDropEffects.None;
        }
        // Add this
        e.Handled = true;
    }
