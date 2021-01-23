    Public SelectedItem
    {
    get
    {
    }
    set
    {
    if(null == SelectedItem || SelectedItem.count > 1)
    IsTabEnabled = false;
    }
    }
