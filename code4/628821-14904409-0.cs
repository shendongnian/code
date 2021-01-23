    public string RemoveBrackets(string Message)
    {
        string temp1 = Message.Split('(')[0];
        string temp2 = Message.Split(')')[1];
        string newMessage = temp1 + temp2;
        return newMessage;
    }
