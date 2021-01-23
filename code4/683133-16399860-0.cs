    var queryResults = clientConnection
        .Cypher
        .Start(new {
            n = Node.ByIndexLookup("NameIndex", "Name", nodeName)
        })
        .Match("n-->x")
        .Return(n => new {
            Foo = n.As<VersionNode>(),
            CountOfAllNodes = All.Count()
        })
        .Results
        .ToList(); 
