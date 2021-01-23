    static void Main(string[] args)
    {
        var adjList = "A   -  A1" + Environment.NewLine +
                    //"A1  -  A" + Environment.NewLine +
                      "A   -  A2" + Environment.NewLine +
                      "A   -  A3" + Environment.NewLine +
                      "A3  - A31" + Environment.NewLine +
                      "A31 - A311" + Environment.NewLine +
                      "A31 - A312";
    
        var rootsAndChildren = 
        adjList.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
               .Select(s => s.Split('-'))
               .GroupBy(x => x[0].Trim())
               .ToDictionary(x => x.Key, x => x.Select(y => y[1].Trim()).ToList());
        var roots = rootsAndChildren.Keys
                    .Except(rootsAndChildren.SelectMany(x => x.Value));
    
        var sb = new StringBuilder();
        using (var wr = new StringWriter(sb))
        {
            wr.WriteLine("{");
            foreach (var root in roots)
            {
                AppendSubNodes(wr, root, rootsAndChildren, 1);
            }
            wr.WriteLine("};");
        }
    }
    
    private static void AppendSubNodes(TextWriter wr, 
        string root, Dictionary<string, List<string>> rootsAndChildren, int level)
    {
        string indent = string.Concat(Enumerable.Repeat(" ", level * 4));
        wr.Write(indent + "\"name\" : " + root);
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
