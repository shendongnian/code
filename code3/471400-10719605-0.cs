    public string SerialiseAs<TResult>(TResult input)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TResult));
        MemoryStream stream = new MemoryStream();
        ser.WriteObject(stream, input);
        stream.Position = 0;
        StreamReader reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
