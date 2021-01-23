    interface IViewModelBuilder
    {
        void UpdateUserAndMembeDetails(WebSession sessions);
    }
    void UpdateUserAndMembeDetails(WebSessions ws)
    {
        this.memID = ws.IsCUser ? 0 : ws.MemID;
        this.caseUserID = ws.IsCUser ? ws.CUserID : 0;
        this.isMember = !ws.IsCUser; 
        this.isUser = ws.IsCUser;
    }
