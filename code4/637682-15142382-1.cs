    public void UserTyping(groupName)
    {
        var userName = "Get current user's name";
    
        Clients.OthersInGroup(groupName).OtherUserIsTyping(userName);
    }
