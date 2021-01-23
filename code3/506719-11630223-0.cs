    [OnSerializing]
    internal void OnSerializing(StreamingContext context) {
        Console.WriteLine("OnSerializing");
    }
    [OnSerialized]
    internal void OnSerialized(StreamingContext context) {
        Console.WriteLine("OnSerialized");
    }
    [OnDeserializing]
    internal void OnDeserializing(StreamingContext context) {
        Console.WriteLine("OnDeserializing");
    }
    [OnDeserialized]
    internal void OnDeserialized(StreamingContext context) {
        Console.WriteLine("OnDeserialized");
    }
