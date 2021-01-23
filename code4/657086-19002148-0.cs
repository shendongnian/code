    internal IEnumerable<IServerResponseObject> ProcessBackendResponsesEnum(NpgsqlConnector context,
        bool cancelRequestCalled)
    {
        try
        {
        // Process commandTimeout behavior.
        if ((context.Mediator.CommandTimeout > 0) &&
                (!CheckForContextSocketAvailability(context, SelectMode.SelectRead)))
