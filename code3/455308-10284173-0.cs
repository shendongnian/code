        MessageBuffer buffer = message.CreateBufferedCopy(Int32.MaxValue);
        message = buffer.CreateMessage();
        var copy = buffer.CreateMessage();
        XmlDictionaryReader bodyReader = copy.GetReaderAtBodyContents();
        bodyReader.ReadStartElement("Binary");
        byte[] bodyBytes = bodyReader.ReadContentAsBase64();
        string messageBody = Encoding.UTF8.GetString(bodyBytes);
        return messageBody;
