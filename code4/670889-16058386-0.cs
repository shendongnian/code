    var l = new List<string>(s.Split(';'));
    var aggregatedList = new List<List<string>>();
    
    foreach (var item in l)
    {
    	if (item.IndexOf("-") > -1)
    	{
    		var a = item.Split('-').Select(n => int.Parse(n)).ToArray();
    		var parts = Enumerable.Range(a[0], a[1]-a[0]+1).Select(i => i.ToString()).ToList();
    		aggregatedList.Add(parts);
    	}
    }
