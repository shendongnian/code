    var distinctIndexes = array1
    	.Select((item, idx) => new { Item = item, Index = idx })
    	.Aggregate(new Dictionary<int, int>(), (dict, i) =>
    	{
    		if (! dict.ContainsKey(i.Item))
    		{
    			dict[i.Item] = i.Index;
    		}
    		return dict;
    	})
    	.Values;
