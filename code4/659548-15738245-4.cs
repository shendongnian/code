    private MyDataGridItem SelectedDataGridRow;
    
    public MyDataGridItem SelectedDataGridRow
    {
        get
        {
            return selectedDataGridRow;
        }
        set
        {
            selectedDataGridRow= value;
            NotifyPropertyChanged("SelectedDataGridRow");
        }
    }
