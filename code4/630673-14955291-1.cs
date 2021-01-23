    private string _name
    public string Name 
    {
        get { return _name; }
        set { _name = value; DoChange(); }
    }
    
    private string _number
    public string Number 
    {
        get { return _number; }
        set { _number = value; DoChange(); }
    }
    
    public string Label { get { return Name + " " + Number; }}
    
    private void DoChange()
    {
        MyLabel.Text = Label;
    }
