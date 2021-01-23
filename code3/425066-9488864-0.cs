        byte[] unicodeBytes = Encoding.Unicode.GetBytes(ackMessage);
        var asciiBytes = new List<byte>(ackMessage.Length + 3);
        asciiBytes.Add(0x0b);
        asciiBytes.AddRange(Encoding.Convert(Encoding.Unicode, Encoding.ASCII, unicodeBytes));
        asciiBytes.AddRange(new byte[] { 0x1c, 0x0d });
