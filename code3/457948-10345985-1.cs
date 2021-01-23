    public void AddMessagetoGroup(string group, string messageID, string message)
    {
        var findmessage = CreateOrUpdateMessage(messageID, message); 
        var findgroup = Groups.Where(n => String.Equals(n.GroupName, group)).FirstOrDefault();
        if (findgroup != null)
        {
            if (findgroup.GroupMessages.Where(m => m.MessageID == messageID).Count() == 0)
            {
                findgroup.GroupMessages.Add(findmessage);
                findmessage.MessageGroup.Add(findgroup);
            }
        }
    }
