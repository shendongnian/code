    // Convert message to byte array in Windows 1251 encoding
    // Get a byte array that contains the length of messageBytes as string
    byte[] messageBytes = Encoding.GetEncoding("Windows-1251").GetBytes(message);
    byte[] messageBytesLengthBuffer = Encoding.UTF8.GetBytes(messageBytes.Length.ToString());
    stream = client.GetStream();
    stream.Write(messageBytesLengthBuffer, 0, messageBytesLengthBuffer.Length);
    stream.Write(messageBytes, 0, messageBytes.Length);
