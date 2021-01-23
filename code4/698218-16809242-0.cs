    public ObservableCollection<string> FilteredNames
    { 
        get
           {
                if(IsNamesFilterd)
                {
                    return _filteredNames;
                }
                else
                {
                    return _names ;
                }
           }
     }
