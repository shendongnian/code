    public List<Msg> GetNewMessages()
    {
        var newMsg = NewMessages.Except(InboxTemp, new MsgComparer()).ToList();
        foreach(var msg in newMsg)
            InboxTemp.Add(msg);
        return newMsg;
    }
