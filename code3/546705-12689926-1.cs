    static byte[] GetCommandBytes(Command c)
    {
        var command = BitConverter.GetBytes(c.commandID);
        var data = Encoding.UTF8.GetBytes(c.MsgData);
        var both = command.Concat(data).Concat(new byte[1]).ToArray();
        return both;
    }
