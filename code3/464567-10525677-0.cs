    client
        .RootNode
        .OutE<FooPayload>()
        .Select(p =>
        {
            p.Reference.Id,         // Relationship ID
            p.StartNodeReference,   // Outbound vertex
            p.EndNodeReference,     // Inbound vertex
            p.Data,                 // Payload as FooPayload
            p.Data.Bar              // A property in the payload
        });
