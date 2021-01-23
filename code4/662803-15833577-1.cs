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
                        case "ID":
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
