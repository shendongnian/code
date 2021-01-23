    var text1 = File.ReadAllLines(file);
    HashSet<string>[] columns = new HashSet<string>[text1[0].Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length];
            
    for(int i=0; i<columns.Length; i++)
    {
        columns[i] = new HashSet<string>();
    }
    foreach (string row in text1.Skip(1))
    {
        string[] words = row.Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        if (words.Length == columns.Length)
        {
            for (int i = 0; i < words.Length; i++)
            {
                columns[i].Add(words[i]);
            }
        }
    }
    for (int i = 0; i < columns.Length; i++)
    {
        foreach (string value in columns[i])
        {
            Console.WriteLine(value);
        }
    }
