    RelayCommand _autoGeneratingColumnCommand;
    public RelayCommand AutoGeneratingColumnCommand 
    { 
        get 
        { 
            return _autoGeneratingColumnCommand ?? (_autoGeneratingColumnCommand = new RelayCommand(param => 
            { 
                var e = param as DataGridAutoGeneratingColumnEventArgs;
                if (e != null)
                {
                    switch (e.PropertyName)
                    {
                        case "SomeBoolNullableColumnName":
                            e.Column = ... // whatever you wish
                            e.Cancel = true;
                            break;
                        default:
                            break;
                    }
                }
            }, 
            param => true)); 
        } 
    }
