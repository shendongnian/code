    public void UpdateList(){
        if(DataBindings.Count > 0) DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        //The remaining code for populating/updating new items goes below
        ....
    }
