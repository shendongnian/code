    public static byte[] GetLastPacketUsingString(byte[] input, byte delimiter)
    {
        var encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
        string inputString = encoding.GetString(input);
        var parts = inputString.Split(new[] { (char)delimiter }, StringSplitOptions.RemoveEmptyEntries);
        return encoding.GetBytes((char)delimiter + parts[parts.Length - 2] + (char)delimiter);
    }
