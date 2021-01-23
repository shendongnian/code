    GetValuesForUserORMember(dynamic thisView)
    {
        thisView.memID = (WebSessions.IsCUser) ? 0 : WebSessions.MemID;
        thisView.caseUserID = (WebSessions.IsCUser) ? WebSessions.CUserID : 0;
        thisView.isMember = !(WebSessions.IsCUser); 
        thisView.isUser = (WebSessions.IsCUser);
    }
