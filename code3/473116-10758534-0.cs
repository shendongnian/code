    public Button MyChildButton
    {
        get
        {
            EnsureChildControls();
            return _myChildButton;
        }
    }
    private Button _myChildButton;
    ...
    protected override void CreateChildControls()  
    {
        ...
        _myChildButton = new Button();
        ... 
    }
