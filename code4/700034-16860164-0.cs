    var sets = new [] { new [] {1,2,3,4}, new [] {2,3,4}, new [] {1,4}, new [] {1}};
    var results = new List<int[]>();
    foreach (var i in sets.OrderBy(x => x.Length))
    {
    	var leftover = i;
    	foreach (var j in results)
    	{
    		leftover = leftover.Except(j).ToArray();
    	}
    	if (leftover.Any()) { results.Add(leftover); }
    }
