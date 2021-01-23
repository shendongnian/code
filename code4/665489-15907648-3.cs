    RelayCommand _autoGeneratingColumnCommand;
    public RelayCommand AutoGeneratingColumnCommand 
    { 
        get 
        { 
            return _autoGeneratingColumnCommand ?? (_autoGeneratingColumnCommand = new RelayCommand(param => 
            { 
                var e = param as DataGridAutoGeneratingColumnEventArgs;
                var type = ((PropertyDescriptor)e.PropertyDescriptor).PropertyType;
                if (type == typeof(bool?))
                    e.Column = new DataGridCheckBoxColumn();
            }, 
            param => true)); 
        } 
    }
