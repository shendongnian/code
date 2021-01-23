    private Item _selectedItem;
    public Item SelectedItem 
    { 
         get { return _selectedItem; } 
         set { _selectedItem = value; NotifyPropertyChanged("SelectedTrends"); } 
    }
    private RelayCommand _selectedItemCommand;
    public RelayCommand SelectedItemCommand
    {
        get
        {
            return this._selectedItemCommand
                ?? (this._selectedItemCommand= new RelayCommand(() =>
                {
                    MessageDialog messagedialog = new MessageDialog(selectedItem.Name,"Test");
                    messagedialog.ShowAsync();
                }));
        }
    }
