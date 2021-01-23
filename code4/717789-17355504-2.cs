	var groups = new List<HashSet<int>>();
	foreach (var p in sList)
	{
	    var merge = new List<HashSet<int>>();
		foreach(var g in groups)
		{
		    if (g.Contains(p.val1) || g.Contains(p.val2))
			{
			    merge.Add(g);
			}
		}
		
		if (merge.Count == 0)
		{
		    var h = new HashSet<int>();
			groups.Add(h);
			merge.Add(h);
		}
		
		merge[0].Add(p.val1);
		merge[0].Add(p.val2);
		for(int i = 1; i < merge.Count; i ++)
		{
		    foreach(int v in merge[i])
			{
				merge[0].Add(v);
			}
			
			groups.Remove(merge[i]);
		}
	}
