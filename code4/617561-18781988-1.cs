    public ObservableCollection<UserPanel> _ListUserPanelAnchorable;
    ReadOnlyObservableCollection<UserPanel> _readonyFiles = null;
    public ReadOnlyObservableCollection<UserPanel> ListUserPanelAnchorable
    {
        get
        {
            if (_readonyFiles == null)
                _readonyFiles = new ReadOnlyObservableCollection<UserPanel>(_ListUserPanelAnchorable);
    
            return _readonyFiles;
        }
    }
