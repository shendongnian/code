    using (var writer = new StringWriter())
    {
        using (var jsonWriter = new JsonTextWriter(writer))
        {
            serializer.Serialize(jsonWriter, cmd);
            Console.WriteLine(writer.ToString());
        }
    }
