    int byteAsInt = 0;
    var messageBuilder = new StringBuilder();
    var decoder = Encoding.UTF8.GetDecoder();
    var nextChar = new char[1];
    while ((byteAsInt = stream.ReadByte()) != -1)
    {
        var charCount = decoder.GetChars(new[] {(byte) byteAsInt}, 0, 1, nextChar, 0);
        if(charCount == 0) continue;
        Console.Write(nextChar[0]);
        messageBuilder.Append(nextChar);
        if (nextChar[0] == '\r')
        {
            ProcessBuffer(messageBuilder.ToString());
            messageBuilder.Clear();
        }
    }
