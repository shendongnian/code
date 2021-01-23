    static void Main(string[] args)
    {
        var adjList = new List<Link>
        {
            new Link("A","A1"),
            new Link("A","A2"),
            new Link("A","A3"),
            new Link("A3","A31"),
            new Link("A31","A311"),
            new Link("A31","A312"),
        };
    
        var rootsAndChildren = adjList.GroupBy(x => x.From)
               .ToDictionary(x => x.Key, x => x.Select(y => y.To).ToList());
        var roots = rootsAndChildren.Keys
               .Except(rootsAndChildren.SelectMany(x => x.Value));
    
        using (var wr = new StreamWriter("C:\\myjson.json"))
        {
            wr.WriteLine("{");
            foreach (var root in roots)
                AppendSubNodes(wr, root, rootsAndChildren, 1);
            wr.WriteLine("};");
        }
    }
    
    static void AppendSubNodes(TextWriter wr, string root, 
              Dictionary<string, List<string>> rootsAndChildren, int level)
    {
        string indent = string.Concat(Enumerable.Repeat(" ", level * 4));
        wr.Write(indent + "\"name\" : \"" + root + "\"");
        List<string> children;
        if (rootsAndChildren.TryGetValue(root, out children))
        {
            wr.WriteLine(",");
            wr.WriteLine(indent + "\"children\" : [{");
            for (int i = 0; i < children.Count; i++)
            {
                if (i > 0)
                    wr.WriteLine(indent + "}, {");
                AppendSubNodes(wr, children[i], rootsAndChildren, level + 1);
            }
            wr.WriteLine(indent + "}]");
        }
        else
        {
            wr.WriteLine();
        }
    }
