    MyThumbnailControl ctrl = sender as MyThumbnailControl;
    if(ctrl == null) return;
    if(ctrl == SelectedThumbnail) return; // selected again
    if(ctrl != SelectedThumbnail)
    {
        ctrl.IsSelected = true;
        ctrl.BackColor = Color.Blue; 
        // it's better to set the back-color in the IsSelected property setter, not here
        SelectedThumbnail.IsSelected = false;
        SelectedThumbnail.BackColor = Color.Control;
        SelectedThumbnail = ctrl; // important part
    }
