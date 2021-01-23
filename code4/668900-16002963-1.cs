        var a = new string[...];
        var b = new HashSet<string>();
        var c = new HashSet<string>();
        // ... some filling logic here ...
        foreach (var item in a)
        {
            b.Remove(item);
            c.Remove(item);
        }
