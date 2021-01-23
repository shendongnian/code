    public static void RemoveEscapeSequences(List<byte> message)
    {
        var replaceBytes = new Dictionary<byte, byte>()
        {
            {0x00, 0xF8}, {0x01, 0xFB}, {0x02, 0xFD}, {0x03, 0xFE}
        };
    
        // skipped parameter checks
        for (int index = 0; index < message.Count - 1; ++index)
        {
            if (message[index] == 0xF8)
            {
                if(replaceBytes.ContainsKey(message[index + 1]))
    			{
    				message[index] = replaceBytes[message[index + 1]];
    				message.RemoveAt(index + 1);
    			}
            }
        }
    }  
