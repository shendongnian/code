        var a = new HashSet<string>();
        // OR, if you have existing array:
        // var a = new HashSet<string>(myArray);
        var b = new HashSet<string>();
        var c = new HashSet<string>();
        // ... some filling logic here ...
        foreach (var item in b)
        {
            a.Remove(item);
        }
        foreach (var item in c)
        {
            a.Remove(item);
        }
