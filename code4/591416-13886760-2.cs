    private RelayCommand _showItemCommand;
    public RelayCommand ShowItemCommand
    {
        get
        {
            return _showItemCommand ?? (_showItemCommand =
                new RelayCommand(ShowItemDetails, IsItemSelected));
        }
    }
