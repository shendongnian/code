    var content = File.ReadLines("textFile1.txt").Select(line => 
    {
        var parts = line.Split('/');
        return new 
        { 
            Name = parts[0],
            Content = parts[1]
        };
    });
             
    HashSet<string> names = new HashSet<string>(content.Select(c=> c.Name));
    HashSet<string> txt2 = new HashSet<string>(File.ReadLines("textFile2.txt"));
    var uniques = txt2.Where(line => !names.Contains(line.Split('/')[0]));
    
