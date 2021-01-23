    // Attach EventHandler
    PlayerModel.PropertyChanged += PlayerModel_PropertyChanged;
    
    ...
    
    // When property gets changed in the Model, raise the PropertyChanged 
    // event of the ViewModel copy of the property
    PlayerModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SomeProperty")
            RaisePropertyChanged("ViewModelCopyOfSomeProperty");
    }
