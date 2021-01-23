    enum EState
    {
        Off = 0,
        On = 1,
        Waiting = 2
    }
    
    private EState state = EState.Off;
    
    // Provide a state property to check if the state is on or of (waiting is considered to be Off)
    public bool State{ get{ return state == EState.On;} }
