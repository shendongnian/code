    var LeftJoin = from user in Users
    join chat in Chats
    on user.Name equals user.Name into JoinedTables
    from row in JoinedTables.DefaultIfEmpty()
    select new                          
    {
      Name,
      AgentStatus,
      TimeInState,
      TaskHandled,
      Region,
      CChats = chat != null ? chat.CChats : 0
      AChats = chat != null ? chat.AChats : 0                          
    };
