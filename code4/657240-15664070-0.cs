    //this should be in second form
    string _myProperty;
    public string MyProperty
    {
        get{return _myProperty;}
        set{_myProperty=value; if(MyPropertyChanged!=null)MyPropertyChanged(this,null);}
    }
    
    public event EventHandler MyPropertyChanged;
    //assign value to MyProperty when your dataGrid changes or whatever
