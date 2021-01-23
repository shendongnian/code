    //can be assigned to externally using = and multicast using +=
    // and can be invoked externally to the class 
    public EventHandler _progressEvent;
    //can be bound to externally using +=
    // and can be invoked internally only eg. using this._progressEvent(..)
    public event EventHandler _progressEvent;
    //can be bound using = or += internal to the class only
    //can be invoked by some function internal to the class  
    private EventHandler _progressEvent;
    //Same as private. given event restricts the use of the delegate from outside
    // the class - i don't see how private is different to private event
    private event EventHandler _progressEvent;
