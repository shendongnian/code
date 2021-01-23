    private ImageTile _selectedItem;
    public ImageTile SelectedItem
    {
         get {return _selectedItem;}
         set
         {
             if(value != _selectedItem)
             { 
                  _selectedItem = value;
                  RaisePropertyChanged("SelectedItem");
             }
         }
    }
