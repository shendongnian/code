    static void Main(string[] args)
    {
        var xml = @"<root><child><thenode>hello</thenode></child><child><thenode></thenode></child></root>";
        XDocument doc = XDocument.Parse(xml);
        var parentsWithEmptyChild = doc.Element("root")
            .Descendants() // gets all descendants regardless of level
            .Where(d => string.IsNullOrEmpty(d.Value)) // find only ones with an empty value
            .Select(d => d.Parent) // Go one level up to parents of elements that have empty value
            .Where(d => d.Elements().Count() == 1); // Of those that are parents take only the ones that just have one element
        parentsWithEmptyChild.ForEach(Console.WriteLine);
    
        Console.ReadKey();
    }
