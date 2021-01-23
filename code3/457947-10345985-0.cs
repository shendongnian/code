    public Message CreateOrUpdateMessage(string messageID, string groupMessage)
    {
        var findmessage = Messages.Where(s => s.MessageID == messageID).FirstOrDefault();
        if (findmessage != null)
        {
            findmessage.GroupMessage = groupMessage;
        }
        else
        {
            findmessage = new Message() { MessageID = messageID, GroupMessage = groupMessage};
            Messages.Add(findmessage);
        }
        return findmessage;
    }
