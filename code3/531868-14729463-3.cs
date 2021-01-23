    var jsonSerializer = Newtonsoft.Json.JsonSerializer.Create();
    var sb = new StringBuilder(256);
    var sw = new StringWriter(sb, CultureInfo.InvariantCulture);
    using (var jsonWriter = new JsonTextWriterOptimized(sw))
    {
        jsonWriter.Formatting = Formatting.None;
        jsonSerializer.Serialize(jsonWriter, instance);
    }
