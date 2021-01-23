    var lines1 = System.IO.File.ReadLines(path1);
    var lines2 = System.IO.File.ReadLines(path2);
    var allItems = new Dictionary<String, String>();
    foreach (var line in lines1.Concat(lines2))
    {
        String[] tokens = line.Split('/');
        if (tokens.Length == 2)
        {
            String name = tokens[0];
            String number = tokens[1];
            allItems[name] = number;
        }
    }
