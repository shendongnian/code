    // prevents dragging from other instances of this form - thanks to Hans Passant
    private bool DragDropFromThisForm = false;
    private void SubFolderTreeView_ItemDrag(object sender, ItemDragEventArgs e)
    {
        // Initiate drag/drop
        DragDropFromThisForm = true;
        DoDragDrop(e.Item, DragDropEffects.Move);
        DragDropFromThisForm = false;
    }
    private void SubFolderTreeView_DragEnter(object sender, DragEventArgs e)
    {
        MyForm form = (MyForm) (sender as TreeView).TopLevelControl;
        if (form.DragDropFromThisForm && e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            e.Effect = DragDropEffects.Move; // Okay, set the visual effect
        else
            e.Effect = DragDropEffects.None; // Unknown data, ignore it
    }
