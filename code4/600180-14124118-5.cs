    public IEnumerable<someclass> MergeList(IEnumerable<someclass> list)
    {
        // use 'GroupBy' for grouping, obv.
    	foreach(var g in list.GroupBy(l => Tuple.Create(l.CompanyName, l.CompanyNumber)))
    	{
            // use 'Select', 'Aggregate' and '??' to find the first non-empty string for each property
    		var adress = g.Select(x => x.address).Aggregate((x, y) => x ?? y);
    		var alternative = g.Select(x => x.Alternativeaddress).Aggregate((x, y) => x ?? y);
            // return a new 'someclass'
    		yield return new someclass(g.Key.Item1, adress, alternative, g.Key.Item2);	
    	}
    }
