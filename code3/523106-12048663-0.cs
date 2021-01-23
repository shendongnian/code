    //.....
    InitalizeComponent();
    this.GotFocus += (myFocusCheck);
    //...
    private bool onTop = false;
    
    private void myFocusCheck(object s, EventArgs e)
    {
        if(GetFore......){ onTop = true; }
    }
