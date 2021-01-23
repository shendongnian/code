        using (var ms = new MemoryStream())
        {
            serializer.Serialize(ms, metricResults);
            serializer.Deserialize(ms);
        }
