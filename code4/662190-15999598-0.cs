    public static byte[] GetLastPacketUsingLINQ(byte[] input, byte delimiter)
    {
        var part = input.Reverse()
                        .SkipWhile(i => i != delimiter)
                        .SkipWhile(i => i == delimiter)
                        .TakeWhile(i => i != delimiter)
                        .Reverse();
        return (new byte[] { delimiter }).Concat(part).Concat(new byte[] { delimiter }).ToArray();
    }
