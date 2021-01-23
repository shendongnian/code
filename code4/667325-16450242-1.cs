    var document = new HashTableDocument
    {
        Id = ObjectId.GenerateNewId(),
        Values = new Dictionary<string, object>
        {
            { "metadata1", "asaad" },
            { "metadata2", new object[0] },
            { "metadata3", DateTime.UtcNow }
        }
    };
    collection.Insert(document);
