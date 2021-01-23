    public void WriteReply(string message)
    {
        var result = WriteReplyExternal(message, message.Length);
        if (result == false)
            throw new ApplicationException("WriteReplay failed ...");
    }
