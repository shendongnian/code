    // Creates serializer.
    var serializer = SerializationContext.Default.GetSerializer<T>();
    // Pack obj to stream.
    serializer.Pack(stream, obj);
    // Unpack from stream.
    var unpackedObject = serializer.Unpack(stream);
