    public static void AddCascadeDeleteReference(
      this IAdvancedDocumentSessionOperations session,
      object entity, params string[] documentKeys)
    {
        var metadata = session.GetMetadataFor(entity);
        if (metadata == null)
          throw new InvalidOperationException(
            "The entity must be tracked in the session before calling this method.");
        if (documentKeys.Length == 0)
          throw new ArgumentException(
            "At least one document key must be specified.");
            
        const string metadataKey = "Raven-Cascade-Delete-Documents";
        RavenJToken token;
        if (!metadata.TryGetValue(metadataKey, out token))
            token = new RavenJArray();
        var list = (RavenJArray) token;
        foreach (var documentKey in documentKeys.Where(key => !list.Contains(key)))
            list.Add(documentKey);
        metadata[metadataKey] = list;
    }
