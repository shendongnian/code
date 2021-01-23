    protected Bar selectedItem;
    public Bar SelectedItem{
        get
        {
            return selectedItem;
        }
        set
        {
            selectedItem = null;
            NotifyPropertyChanged("SelectedItem");
    
            selectedItem = value;
            NotifyPropertyChanged("SelectedItem");
        }
