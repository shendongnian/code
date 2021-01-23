    var time = DateTime.Now.AddDays(-1);
    var c = scan.Entries;
    var cutOff = 0;
    for (var i = c.Count - 1; i > - 1; i--)
    {
        if (c[i].TimeGenerated < time)
        {
            cutOff = i;
            break;
        }
    }
    var result = new List<Item>(c.Count - cutOff - 1);
    Enumerable.Range(cutOff + 1, c.Count - cutOff - 1).AsParallel()
        .ForAll(i => 
            {
                var j = i - cutOff - 1;
                result[j] = (Item)c[i];
            }
