    public ObservableCollection<CustomVariableGroup> CustomVariableGroups
    {
        get
        {
            if (this.ShowDisabled) { return this._customVariableGroups; }
            return new ObservableCollection<CustomVariableGroup>  (this._customVariableGroups.Where(x => x.Disabled == false));
        }
    }
    // adds to the backing list but raises on property to rebuild and
    // return the ObservableCollection
    public void AddCustomVariableGroup(CustomVariableGroup newGroup)
    {    
        this._customVariableGroups.Add(newGroup);
        OnPropertyChanged("CustomVariableGroups");
    }
    //Example invocation
    AddCustomVariableGroup(newGroup);
