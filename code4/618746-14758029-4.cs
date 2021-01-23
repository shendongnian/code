    //external.
    int Say(char* message);
    //internal.
    ///<summary>
    /// can throw (CONTRACT): WrongMessageException, SessionTimeOutException
    void Say(string message) {
        int errorCode = External.Say(message);
        //translate error code to either WrongMessageException or to SessionTimeOutException.
    }
    
