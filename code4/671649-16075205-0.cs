    var dict = products
    	.GroupBy(p => p.Category)
    	.ToDictionary(grp => grp.Key, grp => grp.Sum(p => p.Value));
    
    foreach(var item in dict)
    {
    	Console.WriteLine("{0} = {1}", item.Key, item.Value);
    }
