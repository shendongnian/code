    //Populating data
    Dictionary<int, List<string>> GroupedA = new Dictionary<int, List<string>>();
	
	GroupedA.Add(1, new List<string>{"1","2","3"});
	GroupedA.Add(2, new List<string>{"1","32","3","4"});
	GroupedA.Add(3, new List<string>{"1","52","43","4"});
	
    //Inverting data
	ILookup<string, int> GroupedB = 
	       GroupedA.SelectMany(pair => pair.Value.Select(val => new{pair.Key, val}))
			       .ToLookup(pair => pair.val, pair => pair.Key);
			
		
    //Printing data	
	var pairs = GroupedB.Select(pair => string.Format("{0} : {1}", pair.Key, string.Join(",", pair)));
	
	Console.WriteLine (string.Join(Environment.NewLine, pairs));
