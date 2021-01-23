    var list = new[] { "a", "a", "b", "c", "d", "b" };
    var grouped = list
    	.GroupBy(s => s)
    	.Select(g => new { Symbol = g.Key, Count = g.Count() });
    
    foreach (var item in grouped)
    {
    	var symbol = item.Symbol;
    	var count = item.Count;
    }
