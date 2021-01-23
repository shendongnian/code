    SessionIDManager Manager = new SessionIDManager(); 
    string NewID = Manager.CreateSessionID(Context); 
    string OldID = Context.Session.SessionID;
    bool redirected = false;
    bool IsAdded = false;
    Manager.SaveSessionID(Context, NewID,out redirected, out IsAdded);
