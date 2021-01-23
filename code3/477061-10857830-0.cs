    public IEnumerable<IMessage> GetMessagesParallel(IEnumerable<IConnection> connections)
    {
        return connections
            .AsParallel()
            .WithDegreeOfParallelism(10)
            .SelectMany(connection => GetMessages(connection));
    }
