    // Parse the bits we need out of that file
    var rootNode = inputDoc.Root;
    if (!rootNode.Name.NamespaceName.Equals(string.Empty, StringComparison.Ordinal))
    {
        throw new InvalidDataException(".abc file format namespace did not match.");
    }
