    var identifiers = new List<string>();
    identifiers.Add("myIdentifier");
    var tablesWithOnlyTheIdentifiersIWant = document.Tables.Select(tableContent => identifiers.Contains(tableContent.Identifier)
    foreach(var tableContent in tablesWithOnlyTheIdentifiersIWant)
    {
         //Do something
    }
