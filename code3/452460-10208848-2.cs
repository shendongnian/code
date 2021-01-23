    void HandlePossibleCommandReply(string reply)
    {
        StateObject state = FindStateObjectForReply(reply);
        if (state != null)
        {
            state.Reply = reply;
            state.ReplyReceived.Set();
            m_internalStateList.Remove(state);
        }
    }
