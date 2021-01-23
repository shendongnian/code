    int index ; 
    public int ID 
    { 
        get 
        { 
            return index; 
        } 
    
        set 
        { 
            index = value; 
            OnPropertyChanged("ID"); 
        }
    }
