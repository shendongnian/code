    public static object DeepClone(object original)
    {
        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter
            {
                Context = new StreamingContext(StreamingContextStates.Clone)
            };
            formatter.Serialize(stream, original);
            stream.Position = 0;
            return formatter.Deserialize(stream);
        }
    }
