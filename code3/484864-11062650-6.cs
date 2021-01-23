    private string _NodeCategory;
    public string NodeCategory
    {
        get
        {
            return _NodeCategory;
        }
        set
        {
            _NodeCategory = value;
            OnPropertyChanged("NodeCategory");
        }
    }
