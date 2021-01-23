    private Dictionary<string, string> Dic { get; set; } 
    public string this[string key]
    {
        get { return Dic[key]; }
        set
        {
            if(key != null && Dic[key] != value)
                Dic[key] = value;
            OnPropertyChanged("Item[" + key + "]");
        }
    }
