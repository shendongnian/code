    string contactName;
    public string ContactName
    {
        get 
        {
           return contactName; 
        }
        set 
        {
           contactName = value; 
           OnPropertyChanged("ContactName");
        }
    }
