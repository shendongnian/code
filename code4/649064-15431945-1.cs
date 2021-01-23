    public event EventHandler myPropertyChanged;
    public delegate void MyPropertyChanged(object sender, EventArgs e);
 
    //...
    public string MyProperty
    {
        get
        {
           return _myProperty;
        }
        set
        {
            _myProperty = value;
            if (myPropertyChanged != null)
                myPropertyChanged(this, new EventArgs());
        }
    }
