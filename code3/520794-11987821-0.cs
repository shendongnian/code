    SessionState.SessionIDManager Manager = new SessionState.SessionIDManager(); 
    string NewID = Manager.CreateSessionID(Context); 
    string OldID = Context.Session.SessionID; 
     
    bool IsAdded = false; 
    Manager.SaveSessionID(Context, NewID, false, IsAdded); 
     
    Response.Write("Old SessionId Is : " + OldID); 
    if (IsAdded) { 
        Response.Write("&lt;br/> New Session ID Is : " + NewID); 
    } 
    else { 
        Response.Write("&lt;br/> Session Id did not saved : "); 
    } 
