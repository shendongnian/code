    public void FormatObject(object toFormat, Message message)
    {
        var serializer = new XmlSerializer(toFormat.GetType());
        var stream = new MemoryStream();
        serializer.Serialize(toFormat, stream);
        
        //don't dispose the stream
        message.BodyStream = stream;
        message.Label = toFormat.GetType().AssemblyQualifiedName;
    }
