    var b = a.SelectMany(o => 
    {
        var numOrdersInList = o.Count(o2 => o2.OrderCode == o.OrderCode);
    	return Enumerable.Range(0, o.Quantity - numOrdersInList)
    					 .Select(i => new 
                                     { 
                                         o.OrderCode, 
                                         Assignment = Enumerable.Empty<Assignment>() 
                                     });
    });
