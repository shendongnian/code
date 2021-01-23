    // Load document into XDocument instance.
    var doc = XDocument.Load("source.txt");
    // query for all <activity> element.
    var activities = doc.Root.Elements("activity");
    // add XComment after each of them.
    foreach (var a in activities)
    {
        a.AddAfterSelf(new XComment("------------"));
    }
    // Print document into console.
    Console.WriteLine(doc.ToString());
