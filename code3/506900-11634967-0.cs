    private string _selectedListBoxItem;
    private boolean _textBlockVisibility
    
    public string SelectedListBoxItem
    {
    get {return _selectedListBoxItem;}
    set{_selectedListBoxItem=value;
    _textBlockVisibility=false;}
    }
    
    public Boolean TextBlockVisibilty
    {
    get{return _textBlockVisibility;};
    set {_textBlockVisibility=value;};
    }
