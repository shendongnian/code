    //pseudo code
    
    //WebHeader
    public delegate void Button1Clicked(object[] args);
    //raise this event when the button is clicked
    public event Button1Clicked buttonClicked;
    
    //WebFooter
    public void Method1(object[] params); //for button 1 click
    
    
    
    //In content page which holds both header and footer control
    WebHeader.Button1Clicked+= new WebHeader.Button1Clicked (HandleClick);
    
    public void HandleClick(object[] params)
    {
        WebFooter.Method2(params);
    }
