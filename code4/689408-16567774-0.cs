    void UpdateIndexExecute(int index)
    {
    
    }
    
    bool CanUpdateIndex(int index)
    {
       return true;
    }
    
    public ICommand UpdateIndex { get { return new RelayCommand<int>(UpdateTabIndexExecute, CanUpdateTabIndex); } }
