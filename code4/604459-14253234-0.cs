    //initial string of 10000 entries divided by commas
    string s = string.Join(", ", Enumerable.Range(0, 10000));
    //an array of entries, from the original string
    var ss = s.Split(',');
    //auxiliary index
    int index = 0;
    //divide into groups by 1000 entries
    var groups = ss.GroupBy(w =>
        {
            try
            {
                return index / 1000;
            }
            finally
            {
                ++index;
            }
        });
    //print the key and the number of entries in each group
    foreach (var g in groups)
        Console.WriteLine(g.Key + "\t" + g.Count());
