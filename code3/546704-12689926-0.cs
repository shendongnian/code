    static byte[] GetCommandBytes(Command c)
    {
        var command = BitConverter.GetBytes(c.commandID);
        var data = new ASCIIEncoding().GetBytes(c.MsgData);
        var both = command.Concat(data).Concat(new byte[1]).ToArray();
        return both;
    }
