    SessionIDManager Manager = new SessionIDManager();
 
    string NewID = Manager.CreateSessionID(Context);
    string OldID = Context.Session.SessionID;
    bool redirected = false;
    bool IsAdded = false;
    Manager.SaveSessionID(Context, NewID,out redirected, out IsAdded);
    Response.Write("Old SessionId Is : " + OldID);
    if (IsAdded)
    {
        Response.Write("<br/> New Session ID Is : " + NewID);
    }
    else
    {
        Response.Write("<br/> Session Id did not saved : ");
    }
