    foreach (var group in filteredTools) 
    {
        // This is actually an anonymous type...
        Console.WriteLine("Module name: {0}", group.ModuleName);
        foreach (Tool tool in group.Values)
        {
            Console.WriteLine("  Tool: {0}", tool);
        }
    }
