        // create a large object
        var obj = new List<ToSerialize>();
        for(int i = 0; i <= 1000; i ++)
            obj.Add(new ToSerialize { Test = "This is my very loooong message" });
        // create my special stream to read from
        var ms = new PullStream();
        new Thread(x =>
        {
            ProtoBuf.Serializer.Serialize(ms, obj);
            ms.End();
        }).Start();
        var buffer = new byte[100];
        // stream to write back to (just to show deserialization is working too)
        var ws = new MemoryStream();
        int read;
        while ((read = ms.Read(buffer, 0, 100)) != 0)
        {
            ws.Write(buffer, 0, read);
            Debug.WriteLine("read some data");
        }
        ws.Position = 0;
        var back = ProtoBuf.Serializer.Deserialize<List<ToSerialize>>(ws);
