    public ViewModel SelectedVm
    {
        get { return _selectedVm; }
        set
        {        
            _selectedVm = value;
            if (_selectedVm != null && _selectedVm.load == true)
            {
               _selectedVm.Load();                   
               _selectedVm.load = false;
            }
            OnPropertyChanged(this, o => o.SelectedVm);               
        }
    }
