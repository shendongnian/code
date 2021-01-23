    public int SelectedVMIndex {
      get {
        return _selectedVMIndex;
      }
      set {
        if (_selectedVMIndex == value) {
          return;
        }
        _selectedVMIndex = value;
        RaisePropertyChanged(() => SelectedVMIndex);
        CurrentPageViewModel = _pagesViewModel[_selectedVMIndex];
      }
    }
