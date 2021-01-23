    void SetValuesForUserORMember(IViewModel viewModel)
    {
        viewModel.memID = WebSessions.IsCUser ? 0 : WebSessions.MemID;
        viewModel.caseUserID = WebSessions.IsCUser ? WebSessions.CUserID : 0;
        viewModel.isMember = !WebSessions.IsCUser; 
        viewModel.isUser = WebSessions.IsCUser;
    }
