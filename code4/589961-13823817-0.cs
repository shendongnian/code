    var parts = "3, 7, 12-14, 1, 5-6".Split(new string[] {", "}, StringSplitOptions.None).ToList();
    
    var finalResult = new List<int>();
    foreach(var item in parts)
    {
        if(item.Contains("-"))
    	{
    	    var rangeParts = item.Split('-');
    		var first = int.Parse(rangeParts[0]);
    		var second = int.Parse(rangeParts[1]);
    	
    		var result = Enumerable.Range(first, second - first + 1); 
    		
    		finalResult.AddRange(result);
    	}
        else
    	{
    	   finalResult.Add(int.Parse(item));
    	}
    }
    var sorted = finalResult.OrderBy(i => i);
    var result = string.Join(", ", sorted);
