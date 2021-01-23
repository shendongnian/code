    var messageBuilder = new List<byte>();
    int byteAsInt;
    while ((byteAsInt = stream.ReadByte()) != -1)
    {
        messageBuilder.Add((byte)byteAsInt);
        if (byteAsInt == '\r')
        {
            var messageString = Encoding.UTF8.GetString(messageBuilder.ToArray());
            Console.Write(messageString);
            ProcessBuffer(messageString);
            messageBuilder.Clear();
        }
    }
