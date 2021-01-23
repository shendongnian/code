    public EventHandler _progressEvent;
    //can be assigned to from outside the class (using = and multicast using +=)
    //can be invoked from outside the class 
    
    public event EventHandler _progressEvent;
    //can be bound to from outside the class (using +=), but can't be assigned (using =)
    //can only be invoked from inside the class
    
    private EventHandler _progressEvent;
    //can be bound from inside the class (using = or +=)
    //can be invoked inside the class  
    
    private event EventHandler _progressEvent;
    //Same as private. given event restricts the use of the delegate from outside
    // the class - i don't see how private is different to private event
    
