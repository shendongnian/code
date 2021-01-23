    protected override OnPaint(...) //FORMS ONPAINT OVERRIDE
    {
        if(needBackGround) //INITIAL VALUE AT STARTUP IS FALSE
           drawBackground(); 
    } 
    
    public void ButtonClickHandler(...)
    {
        needBackGround= !needBackGround;  //INVERSE THE VALUE OF BOOLEAN
    }
