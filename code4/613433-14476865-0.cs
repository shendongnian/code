    var xDoc = XDocument.Parse(mySmlString);
    var names = xDoc.Root.Elements("name").Select(x=> x.Value.Trim()).ToArray();
    foreach (var name in names)
    {
        System.Console.WriteLine(name);
    }
