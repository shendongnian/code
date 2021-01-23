    List<string> strings = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h" };
    var trios = strings
        .Select((s, i) => new { Str = s, Index = i })
        .GroupBy(x => x.Index / 3);
    foreach(var trio in trios){
        var newRow = table.Rows.Add(); // your DataTable here
        newRow.ItemArray = trio.Select(x => x.Str).ToArray();
    }
    
