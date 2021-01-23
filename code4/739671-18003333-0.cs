    public class MyFixApplication: DirectedMessageCracker, Application
    {
    ...
    
    public void FromAdmin(Message msg, SessionID sessionId)
    {
        CrackFrom(msg, sessionId);
    }
    
    public void ToAdmin(Message msg, SessionID sessionId)
    {
        CrackTo(msg, sessionId);
    }
    
    public void OnMessageTo(Logon msg, SessionID sessionId)
    {
        //Treat the outgoing message, set user, password, etc
    }
    public void OnMessageFrom(Allocation msg, SessionID sessionId)
    {
        //Treat the incoming Allocation message
    }
    ...and so on
