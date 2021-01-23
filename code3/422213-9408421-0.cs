    public void SomeMethod()
    {
        //Assign the delegate
        KeyBindings[Keys.Right] += Method1;
    }
    
    public PlaceWhereEventGetsRaised()
    {
        object argument1, argument2;
    
        // set the arguments to something
    
        if (KeyBindings[Keys.Right] != null) 
            KeyBindings[Keys.Right](argument1, argument2);
    }
    
    public void Method1(object argument1, object argument2)
    {
        // Do stuff
    }
