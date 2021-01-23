    private void ProcessMessage(Message msg, XmlDictionaryWriter writer)
    {
        msg.WriteStartEnvelope(writer); // start of envelope
        msg.WriteStartBody(writer); // start of body
        var bodyToStringMethod = msg.GetType()
            .GetMethod("BodyToString", BindingFlags.Instance | BindingFlags.NonPublic);
        bodyToStringMethod.Invoke(msg, new object[] {writer}); // write body
        writer.WriteEndElement(); // write end of body
        writer.WriteEndElement(); // write end of envelope
    }
